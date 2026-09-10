using SSE.Services.Interfaces;

namespace SSE.Forms
{
    public partial class ExecutorForm : Form
    {
        private readonly IExecutorService _executorService;
        public ExecutorForm(IExecutorService executorService)
        {
            InitializeComponent();
            _executorService = executorService;
        }

        private void ExecutorForm_Load(object sender, EventArgs e)
        {
            try
            {
                var app = _executorService.ReadAppConfig();
                textBox1.Text = app.SqlDirectory;
                textBox2.Text = app.ServerName;
                textBox3.Text = app.DatabaseName;
                textBox4.Text = app.Username;
                textBox5.Text = string.IsNullOrEmpty(app.Password) ? string.Empty : "********";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Configuration Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
