using Amazon.CDK;

namespace VpcCdk
{
    sealed class Program
    {
        public static void Main(string[] args)
        {
            var app = new App();
            new VpcCdkStack(app, "VpcCdkStack");

            app.Synth();
        }
    }
}
