using System;
using System.Drawing;
using System.Windows.Forms;

namespace TheiaV1
{
    public partial class Form1 : Form
    {
        private Button navButton;
        private Button bottomButton;
        private TrackBar settingsSwipe;
        private Label settingsSwipeLabel;

        private Button settingsCloseButton;
        private Button programNewDestinationButton;
        private Button moreSettingsButton;

        public Form1()
        {
            InitializeComponent();
            CreatePrototypeButtons();
        }

        private void CreatePrototypeButtons()
        {
            // ----- COMMON SETTINGS -----
            // Big font, easy to read / demo
            var bigFont = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);

            navButton = new Button();
            bottomButton = new Button();
            settingsSwipe = new TrackBar();
            settingsSwipeLabel = new Label();
            settingsCloseButton = new Button();
            programNewDestinationButton = new Button();
            moreSettingsButton = new Button();

            navButton.Text = "Navigation";
            bottomButton.Text = "Notify Emergency Contact";
            settingsSwipeLabel.Text = "Caretaker: Swipe to access settings.";
            settingsCloseButton.Text = "Close Settings";

            navButton.Font = bigFont;
            bottomButton.Font = bigFont;
            settingsCloseButton.Font = bigFont;

            settingsSwipe.Minimum = 0;
            settingsSwipe.Maximum = 100;

            // Make the buttons flat and high-contrast
            navButton.FlatStyle = FlatStyle.Flat;
            bottomButton.FlatStyle = FlatStyle.Flat;
            settingsCloseButton.FlatStyle = FlatStyle.Flat;

            navButton.BackColor = Color.LightSteelBlue;
            bottomButton.BackColor = Color.LightGray;
            settingsCloseButton.BackColor = Color.LightSteelBlue;

            navButton.ForeColor = Color.Black;
            bottomButton.ForeColor = Color.Black;
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
            bottomButton.Width = usableWidth;
            settingsSwipe.Width = usableWidth;
            settingsSwipeLabel.Width = usableWidth;
            settingsCloseButton.Width = usableWidth;

            navButton.Height = buttonHeight;
            bottomButton.Height = buttonHeight;
            settingsSwipe.Height = 30;
            settingsCloseButton.Height = buttonHeight;

            navButton.Left = pictureBox1.Left + marginLeftRight;
            bottomButton.Left = navButton.Left;
            settingsSwipe.Left = navButton.Left;
            settingsSwipeLabel.Left = navButton.Left;
            settingsCloseButton.Left = navButton.Left;

            navButton.Top = pictureBox1.Top + marginTop;
            bottomButton.Top = navButton.Bottom + gapBetweenButtons;
            settingsSwipe.Top = bottomButton.Bottom + gapBetweenButtons;
            settingsSwipeLabel.Top = settingsSwipe.Bottom;
            settingsCloseButton.Top = navButton.Top;

            // ----- EVENTS -----
            navButton.Click += NavButton_Click;
            bottomButton.Click += BottomButton_Click;
            navButton.GotFocus += OnFirstPaint;
            settingsSwipe.MouseUp += OnSettingsSwipe;

            // Add buttons to the form and bring them above the phone image
            Controls.Add(navButton);
            Controls.Add(bottomButton);
            Controls.Add(settingsSwipe);
            Controls.Add(settingsSwipeLabel);
            Controls.Add(settingsCloseButton);

            settingsCloseButton.Visible = false;

            navButton.BringToFront();
            bottomButton.BringToFront();
            settingsSwipe.BringToFront();
            settingsSwipeLabel.BringToFront();
            settingsCloseButton.BringToFront();
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
            bottomButton.Visible = false;
            settingsCloseButton.Visible = true;
            settingsSwipe.Visible = false;
            settingsSwipeLabel.Visible = false;
        }

        // Bottom half: simulate scenario #3 (TO-BE)

        private DateTime? lastTapTime = null;
        private bool emergencyNotified = false;

        private void BottomButton_Click(object? sender, EventArgs e)
        {
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
                "THEIA: Your emergency contact has been notified that you are in distress and has been " +
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
