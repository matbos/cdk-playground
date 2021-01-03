using Amazon.CDK;
using Amazon.CDK.AWS.EC2;

namespace VpcCdk
{
    public class VpcCdkStack : Stack
    {
        internal VpcCdkStack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {
            const bool createPaidResources = true;

            var vpcProperties = new VpcProps
            {
                Cidr = "10.10.0.0/16",
                EnableDnsHostnames = true,
                EnableDnsSupport = true,
                NatGateways = createPaidResources ? 1 : 0,
                SubnetConfiguration = new ISubnetConfiguration[]
                {
                    new SubnetConfiguration
                    {
                        CidrMask = 26,
                        Name = "public",
                        SubnetType = SubnetType.PUBLIC,
                    },
                    new SubnetConfiguration
                    {
                        CidrMask = 26,
                        Name = "private",
                        SubnetType = createPaidResources ? SubnetType.PRIVATE : SubnetType.ISOLATED,
                    }
                }
            };
            var vpc = new Vpc(this, "MyVpc", vpcProperties);
        }
    }
}
