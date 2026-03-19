namespace View
{
    /// <summary>
    /// Класс MainForm
    /// </summary>
    partial class MainForm
    {
        /// <summary>
        ///  Необходимая переменная дизайнера
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Метод для явного освобождения ресурсов
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
            _buttonAddTransport = new Button();
            _groupBoxTransport = new GroupBox();
            _gridControlTransport = new DataGridView();
            _buttonRemoveTransport = new Button();
            _buttonFindTransport = new Button();
            _buttonResetTransport = new Button();
            _buttonSaveTransport = new Button();
            _buttonOpenTransport = new Button();
            _groupBoxTransport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_gridControlTransport).BeginInit();
            SuspendLayout();
            // 
            // _buttonAddTransport
            // 
            _buttonAddTransport.Location = new Point(31, 291);
            _buttonAddTransport.Margin = new Padding(3, 2, 3, 2);
            _buttonAddTransport.Name = "_buttonAddTransport";
            _buttonAddTransport.Size = new Size(82, 22);
            _buttonAddTransport.TabIndex = 0;
            _buttonAddTransport.Text = "Добавить";
            _buttonAddTransport.UseVisualStyleBackColor = true;
            _buttonAddTransport.Click += ButtonAddTransportClick;
            // 
            // _groupBoxTransport
            // 
            _groupBoxTransport.Controls.Add(_gridControlTransport);
            _groupBoxTransport.Location = new Point(31, 44);
            _groupBoxTransport.Margin = new Padding(3, 2, 3, 2);
            _groupBoxTransport.Name = "_groupBoxTransport";
            _groupBoxTransport.Padding = new Padding(3, 2, 3, 2);
            _groupBoxTransport.Size = new Size(640, 243);
            _groupBoxTransport.TabIndex = 1;
            _groupBoxTransport.TabStop = false;
            _groupBoxTransport.Text = "Список транспорта";
            // 
            // _gridControlTransport
            // 
            _gridControlTransport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _gridControlTransport.Location = new Point(7, 20);
            _gridControlTransport.Margin = new Padding(3, 2, 3, 2);
            _gridControlTransport.Name = "_gridControlTransport";
            _gridControlTransport.RowHeadersWidth = 51;
            _gridControlTransport.Size = new Size(626, 218);
            _gridControlTransport.TabIndex = 0;
            // 
            // _buttonRemoveTransport
            // 
            _buttonRemoveTransport.Location = new Point(118, 291);
            _buttonRemoveTransport.Margin = new Padding(3, 2, 3, 2);
            _buttonRemoveTransport.Name = "_buttonRemoveTransport";
            _buttonRemoveTransport.Size = new Size(82, 22);
            _buttonRemoveTransport.TabIndex = 2;
            _buttonRemoveTransport.Text = "Удалить";
            _buttonRemoveTransport.UseVisualStyleBackColor = true;
            _buttonRemoveTransport.Click += ButtonRemoveTransportClick;
            // 
            // _buttonFindTransport
            // 
            _buttonFindTransport.Location = new Point(494, 291);
            _buttonFindTransport.Margin = new Padding(3, 2, 3, 2);
            _buttonFindTransport.Name = "_buttonFindTransport";
            _buttonFindTransport.Size = new Size(82, 22);
            _buttonFindTransport.TabIndex = 0;
            _buttonFindTransport.Text = "Найти";
            _buttonFindTransport.UseVisualStyleBackColor = true;
            _buttonFindTransport.Click += ButtonFindTransportClick;
            // 
            // _buttonResetTransport
            // 
            _buttonResetTransport.Location = new Point(581, 291);
            _buttonResetTransport.Margin = new Padding(3, 2, 3, 2);
            _buttonResetTransport.Name = "_buttonResetTransport";
            _buttonResetTransport.Size = new Size(82, 22);
            _buttonResetTransport.TabIndex = 0;
            _buttonResetTransport.Text = "Сбросить";
            _buttonResetTransport.UseVisualStyleBackColor = true;
            _buttonResetTransport.Click += ButtonResetTransportClick;
            // 
            // _buttonSaveTransport
            // 
            _buttonSaveTransport.Location = new Point(31, 17);
            _buttonSaveTransport.Margin = new Padding(3, 2, 3, 2);
            _buttonSaveTransport.Name = "_buttonSaveTransport";
            _buttonSaveTransport.Size = new Size(82, 22);
            _buttonSaveTransport.TabIndex = 0;
            _buttonSaveTransport.Text = "Сохранить";
            _buttonSaveTransport.UseVisualStyleBackColor = true;
            _buttonSaveTransport.Click += ButtonSaveTransportClick;
            // 
            // _buttonOpenTransport
            // 
            _buttonOpenTransport.Location = new Point(118, 17);
            _buttonOpenTransport.Margin = new Padding(3, 2, 3, 2);
            _buttonOpenTransport.Name = "_buttonOpenTransport";
            _buttonOpenTransport.Size = new Size(82, 22);
            _buttonOpenTransport.TabIndex = 0;
            _buttonOpenTransport.Text = "Открыть";
            _buttonOpenTransport.UseVisualStyleBackColor = true;
            _buttonOpenTransport.Click += ButtonOpenTransportClick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(_buttonRemoveTransport);
            Controls.Add(_groupBoxTransport);
            Controls.Add(_buttonOpenTransport);
            Controls.Add(_buttonResetTransport);
            Controls.Add(_buttonSaveTransport);
            Controls.Add(_buttonFindTransport);
            Controls.Add(_buttonAddTransport);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainForm";
            _groupBoxTransport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_gridControlTransport).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button _buttonAddTransport;
        private GroupBox _groupBoxTransport;
        private DataGridView _gridControlTransport;
        private Button _buttonRemoveTransport;
        private Button _buttonFindTransport;
        private Button _buttonResetTransport;
        private Button _buttonSaveTransport;
        private Button _buttonOpenTransport;
    }
}
