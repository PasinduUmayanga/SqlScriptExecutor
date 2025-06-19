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
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
