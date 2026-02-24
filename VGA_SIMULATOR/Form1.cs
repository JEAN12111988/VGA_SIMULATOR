using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VGA_SIMULATOR
{
	public partial class Form1 : Form
	{
		string caminhoPPM;
		string caminhoOUT;
		private bool rodando = false;
		int frameIndex = 0;
		int totalFrames = 0;
		private string pastaFrames;
		private bool simulacaoCarregada = false;
		private Process processoSimulacao;

		public Form1()
		{
			InitializeComponent();
			this.DoubleBuffered = true;

			rdUnicoF.Checked = true;
			pBarFrame.Visible = false;
			pBarFrame.Minimum = 0;
			WriteLineThreadLOG(txtLOG, "Software Inicializado...");
		}

		private void btnCarregaPPM_Click(object sender, EventArgs e)
		{
			if (rdMultiF.Checked)
			{
				using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
				{
					folderDialog.Description = "Selecione a pasta onde estão os frames";

					if (!string.IsNullOrEmpty(Properties.Settings.Default.UltimaPastaFrames))
					{
						folderDialog.SelectedPath = Properties.Settings.Default.UltimaPastaFrames;
					}

					if (folderDialog.ShowDialog() == DialogResult.OK)
					{
						pastaFrames = folderDialog.SelectedPath;
						txtPPM.Text = pastaFrames;

						try
						{
							totalFrames = Directory.GetFiles(pastaFrames, "frame_*.ppm").Length;
							if (totalFrames == 0)
							{
								WriteLineThreadLOG(txtLOG, "Nenhum frame encontrado na pasta.");
								ShowMessageThread("Nenhum frame encontrado na pasta", "Erro ao carregar os frames", MessageBoxIcon.Error);
								return;
							}
								
						}
						catch(Exception ex)
						{
							WriteLineThreadLOG(txtLOG, "Erro ao acessar pasta de frames: " + ex.Message);
						}
						
						frameIndex = 0;

						Properties.Settings.Default.UltimaPastaFrames = pastaFrames;
						Properties.Settings.Default.Save();
					}
				}
			}
			else if (rdUnicoF.Checked)
			{
				OpenFileDialog openFileDialog = new OpenFileDialog();
				openFileDialog.Title = "Selecionar Frame Único";
				openFileDialog.Filter = "Arquivo PPM (*.ppm)|*.ppm";
				openFileDialog.Multiselect = false;

				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					caminhoPPM = openFileDialog.FileName;
					txtPPM.Text = caminhoPPM;
					totalFrames = 1;  // importante
				}
			}
		}

		private void btnCarregaOUT_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Title = "Selecionar Arquivo de SIMULACAO";
			openFileDialog.Filter = "Arquivos out (*.out)|*.out";
			openFileDialog.Multiselect = false; // permite selecionar apenas 1 arquivo

			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				caminhoOUT = openFileDialog.FileName;
				txtSIM.Text = caminhoOUT;
			}
		}

		private async Task RunSimulationAsync()
		{
			await Task.Run(() =>
			{
				Process p = new Process();
				p.StartInfo.FileName = "vvp";
				p.StartInfo.Arguments = caminhoOUT;
				p.StartInfo.UseShellExecute = false;
				p.StartInfo.CreateNoWindow = true;

				p.Start();
				p.WaitForExit();
			});
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			try
			{
				if (rdUnicoF.Checked)
				{
					timer1.Stop();
					LoadFrame();
					return;
				}

				// modo múltiplos frames
				if (totalFrames == 0)
					return;

				string file = Path.Combine(pastaFrames, $"frame_{frameIndex}.ppm");

				caminhoPPM = file;
				LoadFrame();

				frameIndex++;

				if (frameIndex >= totalFrames)
					frameIndex = 0;  // loop perfeito
			}
			catch (Exception ex)
			{
				timer1.Stop();
				WriteLineThreadLOG(txtLOG, "Erro no timer: " + ex.Message);
			}
		}

		private void LoadFrame()
		{
			try
			{
				if (!File.Exists(caminhoPPM))
				{
					WriteLineThreadLOG(txtLOG, "Arquivo PPM não encontrado.");
					return;
				}

				using (FileStream fs = new FileStream(caminhoPPM, FileMode.Open))
				using (BinaryReader br = new BinaryReader(fs))
				{
					string magic = ReadLine(br);
					string size = ReadLine(br);
					string max = ReadLine(br);

					string[] dims = size.Split(' ');
					int width = int.Parse(dims[0]);
					int height = int.Parse(dims[1]);

					Bitmap bmp = new Bitmap(width, height,
						System.Drawing.Imaging.PixelFormat.Format24bppRgb);

					var rect = new Rectangle(0, 0, width, height);
					var bmpData = bmp.LockBits(rect,
						System.Drawing.Imaging.ImageLockMode.WriteOnly,
						bmp.PixelFormat);

					IntPtr ptr = bmpData.Scan0;
					int bytes = Math.Abs(bmpData.Stride) * height;
					byte[] rgbValues = br.ReadBytes(width * height * 3);

					System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, rgbValues.Length);

					bmp.UnlockBits(bmpData);

					picTELA.Image = bmp;
				}
			}
			catch (Exception ex)
			{
				WriteLineThreadLOG(txtLOG, "Erro ao carregar frame: " + ex.Message);
			}
		}


		private string ReadLine(BinaryReader br)
		{
			List<byte> bytes = new List<byte>();
			byte b;

			while (true)
			{
				b = br.ReadByte();
				if (b == 10) break; // '\n'
				if (b != 13) bytes.Add(b); // ignora '\r'
			}

			return System.Text.Encoding.ASCII.GetString(bytes.ToArray()).Trim();
		}

		private async void btnCarregar_Click(object sender, EventArgs e)
		{
			if (simulacaoCarregada)
			{
				ResetarSimulacao();
				return;
			}

			if (string.IsNullOrEmpty(caminhoOUT))
			{
				MessageBox.Show("Selecione o arquivo .out primeiro");
				return;
			}

			frameIndex = 0;

			pBarFrame.Visible = true;
			pBarFrame.Style = ProgressBarStyle.Blocks;
			pBarFrame.Minimum = 0;
			pBarFrame.Maximum = 100;
			pBarFrame.Value = 0;

			processoSimulacao = new Process();
			processoSimulacao.StartInfo.FileName = "vvp";
			processoSimulacao.StartInfo.Arguments = caminhoOUT;
			processoSimulacao.StartInfo.UseShellExecute = false;
			processoSimulacao.StartInfo.CreateNoWindow = true;
			processoSimulacao.EnableRaisingEvents = false; // NÃO vamos usar evento Exited

			try
			{
				processoSimulacao.Start();
				WriteLineThreadLOG(txtLOG, "Carregando Frame, Aguarde..");

				int progress = 0;

				var progressTask = Task.Run(async () =>
				{
					while (!processoSimulacao.HasExited)
					{
						if (progress < 95)
							progress++;

						Invoke(new Action(() =>
						{
							pBarFrame.Value = progress;
						}));

						await Task.Delay(30);
					}
				});

				await Task.Run(() => processoSimulacao.WaitForExit());
				await progressTask;

				pBarFrame.Value = 100;
				await Task.Delay(200);
			}
			catch (Exception ex)
			{
				WriteLineThreadLOG(txtLOG, "Erro ao executar simulação: " + ex.Message);
				pBarFrame.Visible = false;
				return;
			}

			pBarFrame.Visible = false;

			if (rdMultiF.Checked)
			{
				timer1.Interval = 60;
				timer1.Start();
			}
			else
			{
				LoadFrame();
			}

			simulacaoCarregada = true;
			btnCarregar.Text = "RECARREGAR";

			WriteLineThreadLOG(txtLOG, "Frame carregado!");
		}

		// funções auxiliares
		public void WriteLineThreadLOG(TextBox txtLog, string msg)
		{
			string linha = $"[{DateTime.Now:dd/MM/yy HH:mm:ss}] {msg}{Environment.NewLine}";

			if (txtLog.InvokeRequired)
				txtLog.Invoke(new Action(() => txtLog.AppendText(linha)));
			else
				txtLog.AppendText(linha);
		}

		public void ShowMessageThread(string msg,
							  string titulo = "Aviso",
							  MessageBoxIcon icon = MessageBoxIcon.Information)
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new Action(() =>
				{
					MessageBox.Show(this, msg, titulo,
						MessageBoxButtons.OK, icon);
				}));
			}
			else
			{
				MessageBox.Show(this, msg, titulo,
					MessageBoxButtons.OK, icon);
			}
		}


		private void btnLimparLOG_Click(object sender, EventArgs e)
		{
			txtLOG.Clear();
		}

		private void btnExportLOG_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtLOG.Text))
			{
				MessageBox.Show("O log está vazio.", "Aviso",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			using (SaveFileDialog saveFileDialog = new SaveFileDialog())
			{
				saveFileDialog.Title = "Salvar Log";
				saveFileDialog.Filter = "Arquivo de Texto (*.txt)|*.txt";
				saveFileDialog.DefaultExt = "txt";
				saveFileDialog.FileName = $"LOG_{DateTime.Now:ddMMyy_HHmmss}.txt";

				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					try
					{
						File.WriteAllText(saveFileDialog.FileName, txtLOG.Text);

						MessageBox.Show("Log exportado com sucesso!",
							"Sucesso",
							MessageBoxButtons.OK,
							MessageBoxIcon.Information);
					}
					catch (Exception ex)
					{
						MessageBox.Show("Erro ao salvar arquivo:\n" + ex.Message,
							"Erro",
							MessageBoxButtons.OK,
							MessageBoxIcon.Error);
					}
				}
			}
		}

		private void ResetarSimulacao()
		{
			timer1.Stop();

			if (processoSimulacao != null && !processoSimulacao.HasExited)
			{
				processoSimulacao.Kill();
				processoSimulacao.Dispose();
			}

			caminhoPPM = null;
			caminhoOUT = null;
			pastaFrames = null;

			totalFrames = 0;
			frameIndex = 0;

			txtPPM.Clear();
			txtSIM.Clear();
			picTELA.Image = null;

			pBarFrame.Value = 0;
			pBarFrame.Visible = false;

			simulacaoCarregada = false;
			btnCarregar.Text = "CARREGAR";

			WriteLineThreadLOG(txtLOG, "Simulação resetada.");
		}
	}
}
