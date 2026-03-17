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
            _buttonAddTransport.Location = new Point(35, 388);
            _buttonAddTransport.Name = "_buttonAddTransport";
            _buttonAddTransport.Size = new Size(94, 29);
            _buttonAddTransport.TabIndex = 0;
            _buttonAddTransport.Text = "Добавить";
            _buttonAddTransport.UseVisualStyleBackColor = true;
            _buttonAddTransport.Click += ButtonAddTransportClick;
            // 
            // _groupBoxTransport
            // 
            _groupBoxTransport.Controls.Add(_gridControlTransport);
            _groupBoxTransport.Location = new Point(35, 58);
            _groupBoxTransport.Name = "_groupBoxTransport";
            _groupBoxTransport.Size = new Size(731, 324);
            _groupBoxTransport.TabIndex = 1;
            _groupBoxTransport.TabStop = false;
            _groupBoxTransport.Text = "Список транспорта";
            // 
            // _gridControlTransport
            // 
            _gridControlTransport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _gridControlTransport.Location = new Point(8, 27);
            _gridControlTransport.Name = "_gridControlTransport";
            _gridControlTransport.RowHeadersWidth = 51;
            _gridControlTransport.Size = new Size(715, 291);
            _gridControlTransport.TabIndex = 0;
            // 
            // _buttonRemoveTransport
            // 
            _buttonRemoveTransport.Location = new Point(135, 388);
            _buttonRemoveTransport.Name = "_buttonRemoveTransport";
            _buttonRemoveTransport.Size = new Size(94, 29);
            _buttonRemoveTransport.TabIndex = 2;
            _buttonRemoveTransport.Text = "Удалить";
            _buttonRemoveTransport.UseVisualStyleBackColor = true;
            _buttonRemoveTransport.Click += ButtonRemoveTransportClick;
            // 
            // _buttonFindTransport
            // 
            _buttonFindTransport.Location = new Point(564, 388);
            _buttonFindTransport.Name = "_buttonFindTransport";
            _buttonFindTransport.Size = new Size(94, 29);
            _buttonFindTransport.TabIndex = 0;
            _buttonFindTransport.Text = "Найти";
            _buttonFindTransport.UseVisualStyleBackColor = true;
            _buttonFindTransport.Click += ButtonFindTransportClick;
            // 
            // _buttonResetTransport
            // 
            _buttonResetTransport.Location = new Point(664, 388);
            _buttonResetTransport.Name = "_buttonResetTransport";
            _buttonResetTransport.Size = new Size(94, 29);
            _buttonResetTransport.TabIndex = 0;
            _buttonResetTransport.Text = "Сбросить";
            _buttonResetTransport.UseVisualStyleBackColor = true;
            _buttonResetTransport.Click += ButtonResetTransportClick;
            // 
            // _buttonSaveTransport
            // 
            _buttonSaveTransport.Location = new Point(35, 23);
            _buttonSaveTransport.Name = "_buttonSaveTransport";
            _buttonSaveTransport.Size = new Size(94, 29);
            _buttonSaveTransport.TabIndex = 0;
            _buttonSaveTransport.Text = "Сохранить";
            _buttonSaveTransport.UseVisualStyleBackColor = true;
            _buttonSaveTransport.Click += ButtonSaveTransportClick;
            // 
            // _buttonOpenTransport
            // 
            _buttonOpenTransport.Location = new Point(135, 23);
            _buttonOpenTransport.Name = "_buttonOpenTransport";
            _buttonOpenTransport.Size = new Size(94, 29);
            _buttonOpenTransport.TabIndex = 0;
            _buttonOpenTransport.Text = "Открыть";
            _buttonOpenTransport.UseVisualStyleBackColor = true;
            _buttonOpenTransport.Click += ButtonOpenTransportClick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(_buttonRemoveTransport);
            Controls.Add(_groupBoxTransport);
            Controls.Add(_buttonOpenTransport);
            Controls.Add(_buttonResetTransport);
            Controls.Add(_buttonSaveTransport);
            Controls.Add(_buttonFindTransport);
            Controls.Add(_buttonAddTransport);
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
