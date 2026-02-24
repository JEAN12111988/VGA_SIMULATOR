# 🎮 VGA Simulator - Verilog + C#

Simulador de vídeo VGA desenvolvido com **Verilog (Icarus Verilog)** para geração de frames e **C# (WinForms)** para reprodução da animação.

O projeto demonstra a integração entre:

- 🧠 Lógica digital (HDL)
- 🖥️ Simulação VGA 640x480
- 🎞️ Geração de frames PPM (P6 binário)
- 🎨 Renderização gráfica em C#
- 🔄 Animação de múltiplos frames

---

## 🚀 Como Funciona

### 🔹 Parte 1 — Verilog
O módulo `VgaProcessor`:

- Gera temporização VGA (800x525)
- Define área ativa (ex: 320x240 ou 640x480)
- Implementa um quadrado que rebate nas bordas
- Gera múltiplos arquivos:
frame_0.ppm
frame_1.ppm
...
frame_119.ppm

Formato utilizado:

---

### 🔹 Parte 2 — C#

O aplicativo WinForms:

- Seleciona a pasta dos frames
- Detecta automaticamente o total de frames
- Reproduz animação usando `Timer`
- Usa `LockBits()` para alta performance
- Permite loop contínuo

---

## 🛠️ Requisitos

### 🔹 Verilog
- Icarus Verilog (iverilog + vvp)

### 🔹 C#
- .NET Framework / .NET Windows Forms
- Visual Studio

---

## ⚙️ Como Executar

### 1️⃣ Gerar os frames

No terminal:

```bash
iverilog top_tb.v -o sim.out
vvp sim.out
Isso irá gerar:
frame_0.ppm até frame_119.ppm

### 📐 Arquitetura
Verilog (VGA + Física)
        ↓
Geração PPM (frames)
        ↓
C# (Player gráfico)


---

# 💡 Dica extra

Depois de criar o README:

No terminal do projeto:

```bash
git init
git add .
git commit -m "Initial commit - VGA Simulator Verilog + C#"
git branch -M main
git remote add origin https://github.com/JEAN12111988/VGA_SIMULATOR.git
git push -u origin main
