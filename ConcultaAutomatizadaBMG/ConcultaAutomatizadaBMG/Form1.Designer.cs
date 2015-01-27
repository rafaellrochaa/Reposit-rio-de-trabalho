namespace ConsultaAutomatizadaBMG
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.loginButton = new System.Windows.Forms.Button();
            this.usuarioTextBox = new System.Windows.Forms.TextBox();
            this.senhaTextBox = new System.Windows.Forms.TextBox();
            this.usuarioLabelForm = new System.Windows.Forms.Label();
            this.senhaLabelForm = new System.Windows.Forms.Label();
            this.loginSucessoLabel = new System.Windows.Forms.Label();
            this.ocultaImacrosCheckBox = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_portal = new System.Windows.Forms.Label();
            this.cb_Captcha = new System.Windows.Forms.ComboBox();
            this.lbl_captcha = new System.Windows.Forms.Label();
            this.cb_portal = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cancelarConsultalabel = new System.Windows.Forms.Label();
            this.interromperConsultaButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.caminhoTextBox = new System.Windows.Forms.TextBox();
            this.consultaButton = new System.Windows.Forms.Button();
            this.abrirButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.abrirErrosButton = new System.Windows.Forms.Button();
            this.abrirResultadoButton = new System.Windows.Forms.Button();
            this.arquivoErroLabel = new System.Windows.Forms.Label();
            this.arquivoResultadoLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Arquivo Excel|*.xls;*.xlsx|Todos os arquivos|*.*";
            // 
            // loginButton
            // 
            this.loginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginButton.Location = new System.Drawing.Point(197, 60);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(75, 29);
            this.loginButton.TabIndex = 9;
            this.loginButton.Text = "&Logar";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // usuarioTextBox
            // 
            this.usuarioTextBox.Location = new System.Drawing.Point(82, 37);
            this.usuarioTextBox.Name = "usuarioTextBox";
            this.usuarioTextBox.Size = new System.Drawing.Size(109, 20);
            this.usuarioTextBox.TabIndex = 3;
            // 
            // senhaTextBox
            // 
            this.senhaTextBox.Location = new System.Drawing.Point(82, 63);
            this.senhaTextBox.Name = "senhaTextBox";
            this.senhaTextBox.Size = new System.Drawing.Size(109, 20);
            this.senhaTextBox.TabIndex = 5;
            this.senhaTextBox.UseSystemPasswordChar = true;
            // 
            // usuarioLabelForm
            // 
            this.usuarioLabelForm.AutoSize = true;
            this.usuarioLabelForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usuarioLabelForm.Location = new System.Drawing.Point(12, 37);
            this.usuarioLabelForm.Name = "usuarioLabelForm";
            this.usuarioLabelForm.Size = new System.Drawing.Size(61, 17);
            this.usuarioLabelForm.TabIndex = 2;
            this.usuarioLabelForm.Text = "&Usuário:";
            // 
            // senhaLabelForm
            // 
            this.senhaLabelForm.AutoSize = true;
            this.senhaLabelForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.senhaLabelForm.Location = new System.Drawing.Point(11, 63);
            this.senhaLabelForm.Name = "senhaLabelForm";
            this.senhaLabelForm.Size = new System.Drawing.Size(53, 17);
            this.senhaLabelForm.TabIndex = 4;
            this.senhaLabelForm.Text = "&Senha:";
            // 
            // loginSucessoLabel
            // 
            this.loginSucessoLabel.AutoSize = true;
            this.loginSucessoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginSucessoLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.loginSucessoLabel.Location = new System.Drawing.Point(228, 11);
            this.loginSucessoLabel.Name = "loginSucessoLabel";
            this.loginSucessoLabel.Size = new System.Drawing.Size(122, 17);
            this.loginSucessoLabel.TabIndex = 10;
            this.loginSucessoLabel.Text = "Login Efetuado!";
            this.loginSucessoLabel.Visible = false;
            // 
            // ocultaImacrosCheckBox
            // 
            this.ocultaImacrosCheckBox.AutoSize = true;
            this.ocultaImacrosCheckBox.Location = new System.Drawing.Point(399, 8);
            this.ocultaImacrosCheckBox.Name = "ocultaImacrosCheckBox";
            this.ocultaImacrosCheckBox.Size = new System.Drawing.Size(110, 17);
            this.ocultaImacrosCheckBox.TabIndex = 6;
            this.ocultaImacrosCheckBox.Text = "Ocultar Browser ?";
            this.ocultaImacrosCheckBox.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lbl_portal);
            this.panel1.Controls.Add(this.cb_Captcha);
            this.panel1.Controls.Add(this.lbl_captcha);
            this.panel1.Controls.Add(this.cb_portal);
            this.panel1.Controls.Add(this.usuarioLabelForm);
            this.panel1.Controls.Add(this.loginButton);
            this.panel1.Controls.Add(this.usuarioTextBox);
            this.panel1.Controls.Add(this.senhaTextBox);
            this.panel1.Controls.Add(this.senhaLabelForm);
            this.panel1.Controls.Add(this.loginSucessoLabel);
            this.panel1.Controls.Add(this.ocultaImacrosCheckBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(574, 96);
            this.panel1.TabIndex = 21;
            // 
            // lbl_portal
            // 
            this.lbl_portal.AutoSize = true;
            this.lbl_portal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_portal.Location = new System.Drawing.Point(12, 11);
            this.lbl_portal.Name = "lbl_portal";
            this.lbl_portal.Size = new System.Drawing.Size(49, 17);
            this.lbl_portal.TabIndex = 0;
            this.lbl_portal.Text = "Portal:";
            // 
            // cb_Captcha
            // 
            this.cb_Captcha.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Captcha.FormattingEnabled = true;
            this.cb_Captcha.Items.AddRange(new object[] {
            "Captcha Boss",
            "Death by Captcha"});
            this.cb_Captcha.Location = new System.Drawing.Point(399, 52);
            this.cb_Captcha.Name = "cb_Captcha";
            this.cb_Captcha.Size = new System.Drawing.Size(121, 21);
            this.cb_Captcha.TabIndex = 8;
            // 
            // lbl_captcha
            // 
            this.lbl_captcha.AutoSize = true;
            this.lbl_captcha.Location = new System.Drawing.Point(396, 36);
            this.lbl_captcha.Name = "lbl_captcha";
            this.lbl_captcha.Size = new System.Drawing.Size(125, 13);
            this.lbl_captcha.TabIndex = 7;
            this.lbl_captcha.Text = "Interpretador de Captcha";
            // 
            // cb_portal
            // 
            this.cb_portal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_portal.FormattingEnabled = true;
            this.cb_portal.Items.AddRange(new object[] {
            "BMG",
            "ITAÚ",
            "BCV",
            "CIFRA"});
            this.cb_portal.Location = new System.Drawing.Point(82, 10);
            this.cb_portal.Name = "cb_portal";
            this.cb_portal.Size = new System.Drawing.Size(73, 21);
            this.cb_portal.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cancelarConsultalabel);
            this.panel2.Controls.Add(this.interromperConsultaButton);
            this.panel2.Controls.Add(this.progressBar);
            this.panel2.Controls.Add(this.dataGridView);
            this.panel2.Controls.Add(this.caminhoTextBox);
            this.panel2.Controls.Add(this.consultaButton);
            this.panel2.Controls.Add(this.abrirButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 96);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(574, 503);
            this.panel2.TabIndex = 22;
            // 
            // cancelarConsultalabel
            // 
            this.cancelarConsultalabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancelarConsultalabel.AutoSize = true;
            this.cancelarConsultalabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelarConsultalabel.ForeColor = System.Drawing.Color.Red;
            this.cancelarConsultalabel.Location = new System.Drawing.Point(162, 388);
            this.cancelarConsultalabel.Name = "cancelarConsultalabel";
            this.cancelarConsultalabel.Size = new System.Drawing.Size(188, 17);
            this.cancelarConsultalabel.TabIndex = 6;
            this.cancelarConsultalabel.Text = "Cancelando a consulta...";
            this.cancelarConsultalabel.Visible = false;
            // 
            // interromperConsultaButton
            // 
            this.interromperConsultaButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.interromperConsultaButton.Enabled = false;
            this.interromperConsultaButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.interromperConsultaButton.Location = new System.Drawing.Point(15, 385);
            this.interromperConsultaButton.Name = "interromperConsultaButton";
            this.interromperConsultaButton.Size = new System.Drawing.Size(92, 29);
            this.interromperConsultaButton.TabIndex = 5;
            this.interromperConsultaButton.Text = "&Interromper";
            this.interromperConsultaButton.UseVisualStyleBackColor = true;
            this.interromperConsultaButton.Click += new System.EventHandler(this.interromperConsultaClick);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(177, 67);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(370, 25);
            this.progressBar.TabIndex = 3;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridView.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.dataGridView.Location = new System.Drawing.Point(15, 109);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersWidth = 20;
            this.dataGridView.Size = new System.Drawing.Size(532, 270);
            this.dataGridView.TabIndex = 4;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "CPF";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Convênio";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Situação Consulta";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 200;
            // 
            // caminhoTextBox
            // 
            this.caminhoTextBox.Enabled = false;
            this.caminhoTextBox.Location = new System.Drawing.Point(15, 25);
            this.caminhoTextBox.Name = "caminhoTextBox";
            this.caminhoTextBox.Size = new System.Drawing.Size(493, 20);
            this.caminhoTextBox.TabIndex = 0;
            // 
            // consultaButton
            // 
            this.consultaButton.Enabled = false;
            this.consultaButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consultaButton.Location = new System.Drawing.Point(15, 67);
            this.consultaButton.Name = "consultaButton";
            this.consultaButton.Size = new System.Drawing.Size(145, 25);
            this.consultaButton.TabIndex = 2;
            this.consultaButton.Text = "&Consultar Contratos";
            this.consultaButton.UseVisualStyleBackColor = true;
            this.consultaButton.Click += new System.EventHandler(this.consultaButton_Click);
            // 
            // abrirButton
            // 
            this.abrirButton.Enabled = false;
            this.abrirButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.abrirButton.Location = new System.Drawing.Point(517, 22);
            this.abrirButton.Name = "abrirButton";
            this.abrirButton.Size = new System.Drawing.Size(38, 24);
            this.abrirButton.TabIndex = 1;
            this.abrirButton.Text = "...";
            this.abrirButton.UseVisualStyleBackColor = true;
            this.abrirButton.Click += new System.EventHandler(this.abrirButton_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.abrirErrosButton);
            this.panel3.Controls.Add(this.abrirResultadoButton);
            this.panel3.Controls.Add(this.arquivoErroLabel);
            this.panel3.Controls.Add(this.arquivoResultadoLabel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 517);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(574, 82);
            this.panel3.TabIndex = 23;
            // 
            // abrirErrosButton
            // 
            this.abrirErrosButton.Enabled = false;
            this.abrirErrosButton.Location = new System.Drawing.Point(128, 46);
            this.abrirErrosButton.Name = "abrirErrosButton";
            this.abrirErrosButton.Size = new System.Drawing.Size(63, 23);
            this.abrirErrosButton.TabIndex = 3;
            this.abrirErrosButton.Text = "Erros";
            this.abrirErrosButton.UseVisualStyleBackColor = true;
            this.abrirErrosButton.Click += new System.EventHandler(this.abrirErrosButton_Click);
            // 
            // abrirResultadoButton
            // 
            this.abrirResultadoButton.Enabled = false;
            this.abrirResultadoButton.Location = new System.Drawing.Point(128, 15);
            this.abrirResultadoButton.Name = "abrirResultadoButton";
            this.abrirResultadoButton.Size = new System.Drawing.Size(63, 23);
            this.abrirResultadoButton.TabIndex = 1;
            this.abrirResultadoButton.Text = "Contratos";
            this.abrirResultadoButton.UseVisualStyleBackColor = true;
            this.abrirResultadoButton.Click += new System.EventHandler(this.abrirResultadoButton_Click);
            // 
            // arquivoErroLabel
            // 
            this.arquivoErroLabel.AutoSize = true;
            this.arquivoErroLabel.Location = new System.Drawing.Point(20, 51);
            this.arquivoErroLabel.Name = "arquivoErroLabel";
            this.arquivoErroLabel.Size = new System.Drawing.Size(85, 13);
            this.arquivoErroLabel.TabIndex = 2;
            this.arquivoErroLabel.Text = "Arquivo de erro: ";
            // 
            // arquivoResultadoLabel
            // 
            this.arquivoResultadoLabel.AutoSize = true;
            this.arquivoResultadoLabel.Location = new System.Drawing.Point(20, 20);
            this.arquivoResultadoLabel.Name = "arquivoResultadoLabel";
            this.arquivoResultadoLabel.Size = new System.Drawing.Size(110, 13);
            this.arquivoResultadoLabel.TabIndex = 0;
            this.arquivoResultadoLabel.Text = "Arquivo de resultado: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 599);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta Automatizada BMG";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.TextBox usuarioTextBox;
        private System.Windows.Forms.TextBox senhaTextBox;
        private System.Windows.Forms.Label usuarioLabelForm;
        private System.Windows.Forms.Label senhaLabelForm;
        private System.Windows.Forms.Label loginSucessoLabel;
        private System.Windows.Forms.CheckBox ocultaImacrosCheckBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label cancelarConsultalabel;
        private System.Windows.Forms.Button interromperConsultaButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.TextBox caminhoTextBox;
        private System.Windows.Forms.Button consultaButton;
        private System.Windows.Forms.Button abrirButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button abrirErrosButton;
        private System.Windows.Forms.Button abrirResultadoButton;
        private System.Windows.Forms.Label arquivoErroLabel;
        private System.Windows.Forms.Label arquivoResultadoLabel;
        private System.Windows.Forms.Label lbl_captcha;
        private System.Windows.Forms.ComboBox cb_Captcha;
        private System.Windows.Forms.ComboBox cb_portal;
        private System.Windows.Forms.Label lbl_portal;
    }
}

