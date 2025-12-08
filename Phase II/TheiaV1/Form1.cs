using System;
using System.Drawing;
using System.Windows.Forms;

namespace TheiaV1
{
    public partial class Form1 : Form
    {
        // Main Menu
        private Button navButton;
        private Button emergencyButton;
        private TrackBar settingsSwipe;
        private Label settingsSwipeLabel;

        // Settings Menu
        private Button settingsCloseButton;
        private Button programNewRouteButton;
        private TrackBar volumeSetting;
        private Label volumeSettingLabel;
        private ComboBox languageSetting;
        private Label languageSettingLabel;
        private TextBox emergencyContactName;
        private Label emergencyContactNameLabel;
        private TextBox emergencyContactPhoneNumber;
        private Label emergencyContactPhoneNumberLabel;

        public Form1()
        {
            InitializeComponent();
            CreatePrototypeButtons();
        }

        private void CreatePrototypeButtons()
        {
            this.Text = "THEIA";

            // ----- COMMON SETTINGS -----
            // Big font, easy to read / demo
            var bigFont = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);

            navButton = new Button();
            emergencyButton = new Button();
            settingsSwipe = new TrackBar();
            settingsSwipeLabel = new Label();
            settingsCloseButton = new Button();
            programNewRouteButton = new Button();
            volumeSetting = new TrackBar();
            volumeSettingLabel = new Label();
            languageSetting = new ComboBox();
            languageSettingLabel = new Label();
            emergencyContactName = new TextBox();
            emergencyContactNameLabel = new Label();
            emergencyContactPhoneNumber = new TextBox();
            emergencyContactPhoneNumberLabel = new Label();

            navButton.Text = "Navigation";
            emergencyButton.Text = "Notify Emergency Contact\n(Tap twice)";
            settingsSwipeLabel.Text = "Caretaker: Swipe to access settings.";
            settingsCloseButton.Text = "Close Settings";
            programNewRouteButton.Text = "Program new route";
            volumeSettingLabel.Text = "Volume";
            languageSettingLabel.Text = "Language";
            emergencyContactName.PlaceholderText = "Name";
            emergencyContactNameLabel.Text = "Emergency Contact Name";
            emergencyContactPhoneNumber.PlaceholderText = "##########"; 
            emergencyContactPhoneNumberLabel.Text = "Emergency Contact Phone Number"; 

            languageSetting.Items.Add("English");
            languageSetting.Items.Add("Spanish (Coming soon)");
            languageSetting.DropDownStyle = ComboBoxStyle.DropDownList;
            languageSetting.SelectedIndex = 0;
            settingsSwipe.Minimum = 0;
            settingsSwipe.Maximum = 100;
            volumeSetting.Minimum = 0;
            volumeSetting.Maximum = 100;
            volumeSetting.Value = 100;

            navButton.Font = bigFont;
            emergencyButton.Font = bigFont;
            settingsCloseButton.Font = bigFont;

            // Make the buttons flat and high-contrast
            navButton.FlatStyle = FlatStyle.Flat;
            emergencyButton.FlatStyle = FlatStyle.Flat;
            settingsCloseButton.FlatStyle = FlatStyle.Flat;

            navButton.BackColor = Color.LightSteelBlue;
            emergencyButton.BackColor = Color.LightGray;
            settingsCloseButton.BackColor = Color.LightSteelBlue;

            navButton.ForeColor = Color.Black;
            emergencyButton.ForeColor = Color.Black;
            settingsCloseButton.ForeColor = Color.Black;

            // ----- POSITIONING -----
            int marginLeftRight = 60;
            int marginTop = 140;
            int marginBottom = 160;
            int gapBetweenButtons = 20;

            int usableWidth = pictureBox1.Width - 2 * marginLeftRight;
            int usableHeight = pictureBox1.Height - marginTop - marginBottom;

            int buttonHeight = (usableHeight - gapBetweenButtons) / 2;

            navButton.Width = usableWidth;
            emergencyButton.Width = usableWidth;
            settingsSwipe.Width = usableWidth;
            settingsSwipeLabel.Width = usableWidth;
            settingsCloseButton.Width = usableWidth;
            programNewRouteButton.Width = usableWidth;
            volumeSetting.Width = usableWidth;
            volumeSettingLabel.Width = usableWidth;
            languageSetting.Width = usableWidth;
            languageSettingLabel.Width = usableWidth;
            emergencyContactName.Width = usableWidth;
            emergencyContactNameLabel.Width = usableWidth;
            emergencyContactPhoneNumber.Width = usableWidth;
            emergencyContactPhoneNumberLabel.Width = usableWidth;

            navButton.Height = buttonHeight;
            emergencyButton.Height = buttonHeight;
            settingsSwipe.Height = 30;
            settingsCloseButton.Height = buttonHeight;
            programNewRouteButton.Height = 60;
            volumeSetting.Height = 30;
            volumeSettingLabel.Height = 20;
            languageSetting.Height = 60;
            languageSettingLabel.Height = 20;
            emergencyContactName.Height = 60;
            emergencyContactNameLabel.Height = 20;
            emergencyContactPhoneNumber.Height = 60;
            emergencyContactPhoneNumberLabel.Height = 20;

            navButton.Left = pictureBox1.Left + marginLeftRight;
            emergencyButton.Left = navButton.Left;
            settingsSwipe.Left = navButton.Left;
            settingsSwipeLabel.Left = navButton.Left;
            settingsCloseButton.Left = navButton.Left;
            programNewRouteButton.Left = navButton.Left;
            volumeSetting.Left = navButton.Left;
            volumeSettingLabel.Left = navButton.Left;
            languageSetting.Left = navButton.Left;
            languageSettingLabel.Left = navButton.Left;
            emergencyContactName.Left = navButton.Left;
            emergencyContactNameLabel.Left = navButton.Left;
            emergencyContactPhoneNumber.Left = navButton.Left;
            emergencyContactPhoneNumberLabel.Left = navButton.Left;

            navButton.Top = pictureBox1.Top + marginTop;
            emergencyButton.Top = navButton.Bottom + gapBetweenButtons;
            settingsSwipe.Top = emergencyButton.Bottom + gapBetweenButtons;
            settingsSwipeLabel.Top = settingsSwipe.Bottom;
            settingsCloseButton.Top = navButton.Top;
            programNewRouteButton.Top = settingsCloseButton.Bottom + gapBetweenButtons;
            volumeSettingLabel.Top = programNewRouteButton.Bottom + gapBetweenButtons;
            volumeSetting.Top = volumeSettingLabel.Bottom;
            languageSettingLabel.Top = volumeSetting.Bottom;
            languageSetting.Top = languageSettingLabel.Bottom;
            emergencyContactNameLabel.Top = languageSetting.Bottom;
            emergencyContactName.Top = emergencyContactNameLabel.Bottom;
            emergencyContactPhoneNumberLabel.Top = emergencyContactName.Bottom;
            emergencyContactPhoneNumber.Top = emergencyContactPhoneNumberLabel.Bottom;

            // ----- EVENTS -----
            navButton.Click += NavButton_Click;
            emergencyButton.Click += BottomButton_Click;
            navButton.GotFocus += OnFirstPaint;
            settingsSwipe.MouseUp += OnSettingsSwipe;
            settingsCloseButton.Click += OnSettingsCloseButtonClick;
            programNewRouteButton.Click += OnProgramNewRouteButtonClick;

            // Add buttons to the form and bring them above the phone image
            Controls.Add(navButton);
            Controls.Add(emergencyButton);
            Controls.Add(settingsSwipe);
            Controls.Add(settingsSwipeLabel);
            Controls.Add(settingsCloseButton);
            Controls.Add(programNewRouteButton);
            Controls.Add(volumeSettingLabel);
            Controls.Add(volumeSetting);
            Controls.Add(languageSettingLabel);
            Controls.Add(languageSetting);
            Controls.Add(emergencyContactNameLabel);
            Controls.Add(emergencyContactName);
            Controls.Add(emergencyContactPhoneNumberLabel);
            Controls.Add(emergencyContactPhoneNumber);

            settingsCloseButton.Visible = false;
            programNewRouteButton.Visible = false;
            volumeSettingLabel.Visible = false;
            volumeSetting.Visible = false;
            languageSettingLabel.Visible = false;
            languageSetting.Visible = false;
            emergencyContactNameLabel.Visible = false;
            emergencyContactName.Visible = false;
            emergencyContactPhoneNumberLabel.Visible = false;
            emergencyContactPhoneNumber.Visible = false;

            navButton.BringToFront();
            emergencyButton.BringToFront();
            settingsSwipe.BringToFront();
            settingsSwipeLabel.BringToFront();
            settingsCloseButton.BringToFront();
            programNewRouteButton.BringToFront();
            volumeSettingLabel.BringToFront();
            volumeSetting.BringToFront();
            languageSettingLabel.BringToFront();
            languageSetting.BringToFront();
            emergencyContactNameLabel.BringToFront();
            emergencyContactName.BringToFront();
            emergencyContactPhoneNumberLabel.BringToFront();
            emergencyContactPhoneNumber.BringToFront();
        }

        private bool isFirstPaint = true;

        private void OnFirstPaint(object sender, EventArgs e)
        {
            if (isFirstPaint)
            {
                isFirstPaint = false;
                MessageBox.Show(
                    "THEIA: Welcome to Theia. Tap the top portion of your screen to begin navigation " +
                    "or change your navigation destination.\n\n" +
                    "If you feel distressed or lost, tap the bottom portion of your screen twice to " +
                    "send a message to the emergency contact configured by your caretaker.\n\n" +
                    "(In the real app this would be spoken aloud)",
                    "THEIA - Welcome Message",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        // Top half: simulate Scenario #1 (TO-BE)
        private void NavButton_Click(object? sender, EventArgs e)
        {
            if (emergencyContactName.Text == "" || emergencyContactPhoneNumber.Text == "")
            {
                MessageBox.Show(
                    "THEIA: Please ask your caretaker to set up an emergency contact before using the app.\n\n" +
                    "(In the real app this would be spoken aloud)",
                    "THEIA - Emergency Contact Not Set Up",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return;
            }

            // Step 1: the app "asks" where Stevie wants to go
            MessageBox.Show(
                "THEIA: Where do you want to go?\n\n" +
                "(In the real app this would be spoken aloud and Stevie would reply verbally.)",
                "THEIA – Navigation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            // For the prototype, we just pretend Stevie said "next classroom"
            MessageBox.Show(
                "THEIA: Okay, let's go to your next classroom.\n\n" +
                "Walk ahead 10 steps, then turn left around the corner.\n\n" +
                "I'll let you know exactly when to turn.\n\n" +
                "(Stevie would walk 10 steps)",
                "THEIA – Directions",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            // After he walks 10 steps, vibrate the phone
            MessageBox.Show(
                "THEIA: <<Vibrates phone>> Turn left now.\n\n" +
                "(Stevie would turn left)",
                "THEIA - Directions",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            MessageBox.Show(
                "Now walk ahead 25 steps, then turn right around the corner.\n\n" +
                "I'll let you know exactly when to turn.\n\n" +
                "(The navigation continues until he reaches his destination)",
                "THEIA – Directions",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        // Settings swipe: simulate scenario #2 (TO-BE)
        private void OnSettingsSwipe(object? sender, EventArgs e)
        {
            // Check for accidental swipes
            if (settingsSwipe.Value != 100)
            {
                settingsSwipe.Value = 0;
                return;
            }

            settingsSwipe.Value = 0;

            // Tell user that settings are open and how to close in case they accidentally triggered it
            MessageBox.Show(
                "THEIA: You have opened the settings menu. If you didn't mean " +
                "to do this, tap the top half of your phone screen to close the menu.",
                "THEIA - Settings",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            navButton.Visible = false;
            emergencyButton.Visible = false;
            settingsSwipe.Visible = false;
            settingsSwipeLabel.Visible = false;
            settingsCloseButton.Visible = true;
            programNewRouteButton.Visible = true;
            volumeSettingLabel.Visible = true;
            volumeSetting.Visible = true;
            languageSettingLabel.Visible = true;
            languageSetting.Visible = true;
            emergencyContactNameLabel.Visible = true;
            emergencyContactName.Visible = true;
            emergencyContactPhoneNumberLabel.Visible = true;
            emergencyContactPhoneNumber.Visible = true;
        }

        private void OnSettingsCloseButtonClick(object? sender, EventArgs e)
        {
            navButton.Visible = true;
            emergencyButton.Visible = true;
            settingsSwipe.Visible = true;
            settingsSwipeLabel.Visible = true;
            settingsCloseButton.Visible = false;
            programNewRouteButton.Visible = false;
            volumeSettingLabel.Visible = false;
            volumeSetting.Visible = false;
            languageSettingLabel.Visible = false;
            languageSetting.Visible = false;
            emergencyContactNameLabel.Visible = false;
            emergencyContactName.Visible = false;
            emergencyContactPhoneNumberLabel.Visible = false;
            emergencyContactPhoneNumber.Visible = false;
        }

        private void OnProgramNewRouteButtonClick(object? sender, EventArgs e)
        {
            MessageBox.Show(
                "(In the real app, the camera would open and the caretaker would " +
                "be able to select a destination, waypoints, and define alternate routes.)",
                "THEIA - Route Programming",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void OnMoreSettingsButtonClick(object? sender, EventArgs e)
        {
            MessageBox.Show(
                "(Placeholder for more settings that the app might need)",
                "THEIA - More Settings",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        // Bottom half: simulate scenario #3 (TO-BE)

        private DateTime? lastTapTime = null;
        private bool emergencyNotified = false;

        private void BottomButton_Click(object? sender, EventArgs e)
        {
            if (emergencyContactName.Text == "" || emergencyContactPhoneNumber.Text == "")
            {
                MessageBox.Show(
                    "THEIA: Please ask your caretaker to set up an emergency contact before using the app.\n\n" +
                    "(In the real app this would be spoken aloud)",
                    "THEIA - Emergency Contact Not Set Up",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return;
            }

            if (!lastTapTime.HasValue || DateTime.Now > lastTapTime.Value + new TimeSpan(0, 0, 1))
            {
                lastTapTime = DateTime.Now;
                return;
            }

            if (emergencyNotified)
            {
                MessageBox.Show(
                    "THEIA: Calling 911...\n\n" +
                    "(In the real app this would call 911, or a dummy number if debugging is enabled)",
                    "THEIA - 911 Emergency",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            emergencyNotified = true;
            lastTapTime = null;

            MessageBox.Show(
                "THEIA: " + emergencyContactName.Text + " has been notified that you are in distress and has been " +
                "provided with your current location.\n\n" +
                "Please remain calm. Help is on the way. If it is a serious emergency, tap the button " +
                "twice more to call 911.",
                "THEIA - Emergency",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}
