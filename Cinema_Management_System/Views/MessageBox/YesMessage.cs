using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Cinema_Management_System.Views.MessageBox
{
    public partial class YesMessage : Form
    {

        private Guna2ShadowForm shadowForm;

        public YesMessage(string title, string message, MessageBoxType type)
        {
            InitializeComponent();
            InitMessageBox(title, message, type);
            DragHelper.EnableDrag(this, panel_Title);
            shadowForm = new Guna2ShadowForm();
            shadowForm.SetShadowForm(this);

            shadowForm.ShadowColor = Color.Black;

            shadowForm.BorderRadius = 12;
        }

        private void InitMessageBox(string title, string message, MessageBoxType type)
        {
            title_txt.Text = title;
            message_Txt.Text = message;
            ConfigureMessageText();

            var config = GetMessageBoxConfig(type);
            ApplyMessageBoxConfig(config);
        }

        private void ConfigureMessageText()
        {
            message_Txt.AutoSize = true;
            message_Txt.MaximumSize = new Size(panel_Message.Width - 20, 0);
            message_Txt.AutoEllipsis = false;
            message_Txt.TextAlign = ContentAlignment.TopLeft;
        }

        private MessageBoxConfig GetMessageBoxConfig(MessageBoxType type)
        {
            switch (type)
            {
                case MessageBoxType.Info:
                    return new MessageBoxConfig
                    {
                        Icon = Properties.Resources.icon_Info,
                        Sound = SystemSounds.Asterisk,
                        FillColor1 = Color.FromArgb(0, 196, 253),
                        FillColor2 = Color.FromArgb(0, 112, 251),
                        TextColor = Color.Black,
                        TitleColor = Color.White,
                        ButtonVisibility = (ok: true, yes: false, no: false)
                    };

                case MessageBoxType.Warning:
                    return new MessageBoxConfig
                    {
                        Icon = Properties.Resources.icon_Warning,
                        Sound = SystemSounds.Exclamation,
                        FillColor1 = Color.FromArgb(253, 208, 23),
                        FillColor2 = Color.FromArgb(244, 196, 48),
                        TextColor = Color.Black,
                        TitleColor = Color.White,
                        ButtonVisibility = (ok: false, yes: true, no: true)
                    };

                case MessageBoxType.Error:
                    return new MessageBoxConfig
                    {
                        Icon = Properties.Resources.ErrorIcon,
                        Sound = SystemSounds.Hand,
                        FillColor1 = Color.FromArgb(203, 45, 62),
                        FillColor2 = Color.FromArgb(239, 71, 58),
                        TextColor = Color.Black,
                        TitleColor = Color.White,
                        ButtonVisibility = (ok: true, yes: false, no: false)
                    };

                case MessageBoxType.Success:
                    return new MessageBoxConfig
                    {
                        Icon = Properties.Resources.icon_Succes,
                        Sound = SystemSounds.Asterisk,
                        FillColor1 = Color.FromArgb(34, 139, 34),
                        FillColor2 = Color.FromArgb(50, 205, 50),
                        TextColor = Color.Black,
                        TitleColor = Color.White,
                        ButtonVisibility = (ok: true, yes: false, no: false)
                    };

                case MessageBoxType.Question:
                    return new MessageBoxConfig
                    {
                        Icon = Properties.Resources.icon_Question,
                        Sound = SystemSounds.Question,
                        FillColor1 = Color.FromArgb(0, 196, 253),
                        FillColor2 = Color.FromArgb(0, 112, 251),
                        TextColor = Color.Black,
                        TitleColor = Color.White,
                        ButtonVisibility = (ok: false, yes: true, no: true)
                    };

                default:
                    throw new ArgumentOutOfRangeException(nameof(type), "Unsupported MessageBoxType");
            }
        }

        private void ApplyMessageBoxConfig(MessageBoxConfig config)
        {
            icon_pic.Image = config.Icon;
            config.Sound?.Play();

            panel_Title.FillColor = config.FillColor1;
            panel_Title.FillColor2 = config.FillColor2;
            title_txt.ForeColor = config.TitleColor;
            message_Txt.ForeColor = config.TextColor;

            ConfigureButton(ok_Btn, config.FillColor1, config.FillColor2, config.TitleColor, config.ButtonVisibility.ok);
            ConfigureButton(yes_Btn, config.FillColor1, config.FillColor2, config.TitleColor, config.ButtonVisibility.yes);
            ConfigureButton(no_Btn, config.FillColor1, config.FillColor2, config.TitleColor, config.ButtonVisibility.no);
        }

        private void ConfigureButton(Guna2GradientButton button, Color fillColor1, Color fillColor2, Color textColor, bool isVisible)
        {
            button.FillColor = fillColor1;
            button.FillColor2 = fillColor2;
            button.ForeColor = textColor;
            button.BorderRadius = 8;
            button.Visible = isVisible;
        }

        public class MessageBoxConfig
        {
            public Image Icon { get; set; }
            public SystemSound Sound { get; set; }
            public Color FillColor1 { get; set; }
            public Color FillColor2 { get; set; }
            public Color TextColor { get; set; }
            public Color TitleColor { get; set; }
            public (bool ok, bool yes, bool no) ButtonVisibility { get; set; }
        }

        private void close_Btn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void ok_Btn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void yes_Btn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void no_Btn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}