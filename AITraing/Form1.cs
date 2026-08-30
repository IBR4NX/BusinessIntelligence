namespace AITraing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Load sample data
            var sampleData = new MLModel1.ModelInput()
            {
                Battery_power = 1021F,
                Blue = 1F,
                Clock_speed = 0.5F,
                Dual_sim = 1F,
                Fc = 0F,
                Four_g = 1F,
                Int_memory = 53F,
                M_dep = 0.7F,
                Mobile_wt = 136F,
                N_cores = 3F,
                Pc = 6F,
                Px_height = 905F,
                Px_width = 1988F,
                Ram = 2631F,
                Sc_h = 17F,
                Sc_w = 3F,
                Talk_time = 7F,
                Three_g = 1F,
                Touch_screen = 1F,
                Wifi = 0F,
            };

            //Load model and predict output
            var result = MLModel1.Predict(sampleData);

        }
    }
}
