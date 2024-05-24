using ForceCalculation.Library;
using Microsoft.Extensions.Logging;
using System.Numerics;

const int a = 4, modP1 = 8, modP2 = 16;

Console.OutputEncoding = System.Text.Encoding.UTF8;

using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddSimpleConsole(options =>
{
    options.SingleLine = true;
}));

ILogger logger = factory.CreateLogger<Program>();

ForceSystem fs = new ForceSystem(logger);

Force P1 = new Force(new Vector3(a, 0, 0), new Vector3(a, a, 0), modP1);
Force P2 = new Force(new Vector3(a, a, 0), new Vector3(0, a, a), modP2);

fs.AddForce(P1);
fs.AddForce(P2);

fs.GetMomentum();
