namespace View
{
    partial class DataForm
    {
        /// <summary>
        /// Необходимая переменная дизайнера
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Метод для явного освобождения ресурсов
        /// </summary>
        /// <param name="disposing">true если ресурсы необходимо
        /// удалить,иначе false</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Метод инициализации компонентов
        /// </summary>
        private void InitializeComponent()
        {
            _labelTransportType = new Label();
            _labelFuel = new Label();
            _labelPower = new Label();
            _labelWeight = new Label();
            _labelHybridPower = new Label();
            _groupBoxData = new GroupBox();
            _textBoxWeight = new TextBox();
            _textBoxPower = new TextBox();
            _comboBoxFuel = new ComboBox();
            _groupBoxDataHybridCar = new GroupBox();
            _textBoxHybridPower = new TextBox();
            _comboBoxTransportType = new ComboBox();
            _buttonAgree = new Button();
            _buttonCancel = new Button();
#if DEBUG
            _buttonRandom = new Button();
#endif
            _groupBoxData.SuspendLayout();
            _groupBoxDataHybridCar.SuspendLayout();
            SuspendLayout();
            // 
            // _labelTransportType
            // 
            _labelTransportType.AutoSize = true;
            _labelTransportType.Location = new Point(50, 24);
            _labelTransportType.Name = "_labelTransportType";
            _labelTransportType.Size = new Size(119, 20);
            _labelTransportType.TabIndex = 0;
            _labelTransportType.Text = "Тип транспорта";
            // 
            // _labelFuel
            // 
            _labelFuel.AutoSize = true;
            _labelFuel.Location = new Point(15, 48);
            _labelFuel.Name = "_labelFuel";
            _labelFuel.Size = new Size(69, 20);
            _labelFuel.TabIndex = 0;
            _labelFuel.Text = "Топливо";
            // 
            // _labelPower
            // 
            _labelPower.AutoSize = true;
            _labelPower.Location = new Point(52, 184);
            _labelPower.Name = "_labelPower";
            _labelPower.Size = new Size(117, 20);
            _labelPower.TabIndex = 0;
            _labelPower.Text = "Мощность (л.с.)";
            // 
            // _labelWeight
            // 
            _labelWeight.AutoSize = true;
            _labelWeight.Location = new Point(52, 242);
            _labelWeight.Name = "_labelWeight";
            _labelWeight.Size = new Size(72, 20);
            _labelWeight.TabIndex = 0;
            _labelWeight.Text = "Масса (т)";
            // 
            // _labelHybridPower
            // 
            _labelHybridPower.AutoSize = true;
            _labelHybridPower.Location = new Point(15, 72);
            _labelHybridPower.Name = "_labelHybridPower";
            _labelHybridPower.Size = new Size(117, 20);
            _labelHybridPower.TabIndex = 0;
            _labelHybridPower.Text = "Мощность (л.с.)";
            // 
            // _groupBoxData
            // 
            _groupBoxData.Controls.Add(_labelFuel);
            _groupBoxData.Controls.Add(_textBoxWeight);
            _groupBoxData.Controls.Add(_textBoxPower);
            _groupBoxData.Controls.Add(_comboBoxFuel);
            _groupBoxData.Location = new Point(37, 81);
            _groupBoxData.Name = "_groupBoxData";
            _groupBoxData.Size = new Size(261, 228);
            _groupBoxData.TabIndex = 1;
            _groupBoxData.TabStop = false;
            _groupBoxData.Text = "Данные о двигателе и массе";
            // 
            // _textBoxWeight
            // 
            _textBoxWeight.Location = new Point(15, 184);
            _textBoxWeight.Name = "_textBoxWeight";
            _textBoxWeight.Size = new Size(208, 27);
            _textBoxWeight.TabIndex = 3;
            _textBoxWeight.KeyPress += TextBoxKeyPress;
            // 
            // _textBoxPower
            // 
            _textBoxPower.Location = new Point(15, 126);
            _textBoxPower.Name = "_textBoxPower";
            _textBoxPower.Size = new Size(208, 27);
            _textBoxPower.TabIndex = 3;
            _textBoxPower.KeyPress += TextBoxKeyPress;
            // 
            // _comboBoxFuel
            // 
            _comboBoxFuel.FormattingEnabled = true;
            _comboBoxFuel.Location = new Point(15, 71);
            _comboBoxFuel.Name = "_comboBoxFuel";
            _comboBoxFuel.Size = new Size(208, 28);
            _comboBoxFuel.TabIndex = 2;
            // 
            // _groupBoxDataHybridCar
            // 
            _groupBoxDataHybridCar.Controls.Add(_textBoxHybridPower);
            _groupBoxDataHybridCar.Controls.Add(_labelHybridPower);
            _groupBoxDataHybridCar.Location = new Point(333, 81);
            _groupBoxDataHybridCar.Name = "_groupBoxDataHybridCar";
            _groupBoxDataHybridCar.Size = new Size(180, 228);
            _groupBoxDataHybridCar.TabIndex = 1;
            _groupBoxDataHybridCar.TabStop = false;
            _groupBoxDataHybridCar.Text = "Данные об электрическом двигателе";
            // 
            // _textBoxHybridPower
            // 
            _textBoxHybridPower.Location = new Point(15, 96);
            _textBoxHybridPower.Name = "_textBoxHybridPower";
            _textBoxHybridPower.Size = new Size(151, 27);
            _textBoxHybridPower.TabIndex = 3;
            _textBoxHybridPower.KeyPress += TextBoxKeyPress;
            // 
            // _comboBoxTransportType
            // 
            _comboBoxTransportType.FormattingEnabled = true;
            _comboBoxTransportType.Location = new Point(52, 47);
            _comboBoxTransportType.Name = "_comboBoxTransportType";
            _comboBoxTransportType.Size = new Size(208, 28);
            _comboBoxTransportType.TabIndex = 2;
            _comboBoxTransportType.SelectedIndexChanged += AddGroupBoxDataHybridCar;
            // 
            // _buttonAgree
            // 
            _buttonAgree.Location = new Point(324, 317);
            _buttonAgree.Name = "_buttonAgree";
            _buttonAgree.Size = new Size(94, 29);
            _buttonAgree.TabIndex = 3;
            _buttonAgree.Text = "Добавить";
            _buttonAgree.UseVisualStyleBackColor = true;
            _buttonAgree.Click += ButtonAgreeClick;
            // 
            // _buttonCancel
            // 
            _buttonCancel.Location = new Point(433, 317);
            _buttonCancel.Name = "_buttonCancel";
            _buttonCancel.Size = new Size(94, 29);
            _buttonCancel.TabIndex = 3;
            _buttonCancel.Text = "Отменить";
            _buttonCancel.UseVisualStyleBackColor = true;
            _buttonCancel.Click += ButtonCancelClick;
            // 
            // _buttonRandom
            // 
#if DEBUG
            _buttonRandom.Location = new Point(37, 317);
            _buttonRandom.Name = "_buttonRandom";
            _buttonRandom.Size = new Size(94, 29);
            _buttonRandom.TabIndex = 3;
            _buttonRandom.Text = "Заполнить";
            _buttonRandom.UseVisualStyleBackColor = true;
            _buttonRandom.Click += ButtonRandomClick;
#endif
            // 
            // DataForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(552, 358);
            Controls.Add(_buttonCancel);
#if DEBUG
            Controls.Add(_buttonRandom);
#endif
            Controls.Add(_buttonAgree);
            Controls.Add(_comboBoxTransportType);
            Controls.Add(_labelWeight);
            Controls.Add(_labelPower);
            Controls.Add(_labelTransportType);
            Controls.Add(_groupBoxDataHybridCar);
            Controls.Add(_groupBoxData);
            Name = "DataForm";
            Text = "Добавить транспорт";
            _groupBoxData.ResumeLayout(false);
            _groupBoxData.PerformLayout();
            _groupBoxDataHybridCar.ResumeLayout(false);
            _groupBoxDataHybridCar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

#endregion

        private Label _labelTransportType;
        private Label _labelFuel;
        private Label _labelPower;
        private Label _labelWeight;
        private Label _labelHybridPower;
        private GroupBox _groupBoxData;
        private ComboBox _comboBoxFuel;
        private GroupBox _groupBoxDataHybridCar;
        private ComboBox _comboBoxTransportType;
        private TextBox _textBoxWeight;
        private TextBox _textBoxPower;
        private TextBox _textBoxHybridPower;
        private Button _buttonAgree;
        private Button _buttonCancel;
#if DEBUG
        private Button _buttonRandom;
#endif
    }
}