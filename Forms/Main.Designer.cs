using System.ComponentModel;

namespace SeaBattle.Forms
{
    sealed partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.ButtonAction = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gameToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.resetGame = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.about = new System.Windows.Forms.ToolStripMenuItem();
            this.paramsToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.questions = new System.Windows.Forms.ToolStripMenuItem();
            this.team1name = new System.Windows.Forms.Label();
            this.team2name = new System.Windows.Forms.Label();
            this.team2score = new System.Windows.Forms.Label();
            this.team1score = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonAction
            // 
            this.ButtonAction.BackColor = System.Drawing.Color.White;
            this.ButtonAction.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ButtonAction.Location = new System.Drawing.Point(0, 432);
            this.ButtonAction.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ButtonAction.Name = "ButtonAction";
            this.ButtonAction.Size = new System.Drawing.Size(365, 52);
            this.ButtonAction.TabIndex = 0;
            this.ButtonAction.Text = "Начать";
            this.ButtonAction.UseVisualStyleBackColor = false;
            this.ButtonAction.Click += new System.EventHandler(this.ButtonAction_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStrip,
            this.paramsToolStrip});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(365, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStrip
            // 
            this.gameToolStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetGame,
            this.toolStripSeparator1,
            this.about});
            this.gameToolStrip.Name = "gameToolStrip";
            this.gameToolStrip.Size = new System.Drawing.Size(46, 20);
            this.gameToolStrip.Text = "Игра";
            // 
            // resetGame
            // 
            this.resetGame.Name = "resetGame";
            this.resetGame.Size = new System.Drawing.Size(154, 22);
            this.resetGame.Text = "Начать заново";
            this.resetGame.Click += new System.EventHandler(this.ResetGame_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(151, 6);
            // 
            // about
            // 
            this.about.Name = "about";
            this.about.Size = new System.Drawing.Size(154, 22);
            this.about.Text = "Об игре";
            this.about.Click += new System.EventHandler(this.About_Click);
            // 
            // paramsToolStrip
            // 
            this.paramsToolStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.questions});
            this.paramsToolStrip.Name = "paramsToolStrip";
            this.paramsToolStrip.Size = new System.Drawing.Size(83, 20);
            this.paramsToolStrip.Text = "Параметры";
            // 
            // questions
            // 
            this.questions.Name = "questions";
            this.questions.Size = new System.Drawing.Size(124, 22);
            this.questions.Text = "Вопросы";
            this.questions.Click += new System.EventHandler(this.Questions_Click);
            // 
            // team1name
            // 
            this.team1name.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.team1name.ForeColor = System.Drawing.Color.DarkRed;
            this.team1name.Location = new System.Drawing.Point(0, 387);
            this.team1name.Name = "team1name";
            this.team1name.Size = new System.Drawing.Size(181, 21);
            this.team1name.TabIndex = 3;
            this.team1name.Text = "Команда «НазваниеНазеван»";
            this.team1name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // team2name
            // 
            this.team2name.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.team2name.ForeColor = System.Drawing.Color.SteelBlue;
            this.team2name.Location = new System.Drawing.Point(184, 387);
            this.team2name.Name = "team2name";
            this.team2name.Size = new System.Drawing.Size(181, 21);
            this.team2name.TabIndex = 4;
            this.team2name.Text = "Команда «НазваниеНазеван»";
            this.team2name.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // team2score
            // 
            this.team2score.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.team2score.ForeColor = System.Drawing.Color.SteelBlue;
            this.team2score.Location = new System.Drawing.Point(184, 408);
            this.team2score.Name = "team2score";
            this.team2score.Size = new System.Drawing.Size(181, 21);
            this.team2score.TabIndex = 5;
            this.team2score.Text = "Счёт команды: 0";
            this.team2score.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // team1score
            // 
            this.team1score.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.team1score.ForeColor = System.Drawing.Color.DarkRed;
            this.team1score.Location = new System.Drawing.Point(0, 408);
            this.team1score.Name = "team1score";
            this.team1score.Size = new System.Drawing.Size(181, 21);
            this.team1score.TabIndex = 6;
            this.team1score.Text = "Счёт команды: 0";
            this.team1score.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 484);
            this.Controls.Add(this.team1score);
            this.Controls.Add(this.team2score);
            this.Controls.Add(this.team2name);
            this.Controls.Add(this.team1name);
            this.Controls.Add(this.ButtonAction);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.ShowIcon = false;
            this.Text = "Морской бой";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonAction;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gameToolStrip;
        private System.Windows.Forms.ToolStripMenuItem resetGame;
        private System.Windows.Forms.ToolStripMenuItem paramsToolStrip;
        private System.Windows.Forms.ToolStripMenuItem questions;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem about;
        private System.Windows.Forms.Label team1name;
        private System.Windows.Forms.Label team2name;
        private System.Windows.Forms.Label team2score;
        private System.Windows.Forms.Label team1score;
    }
}
