using Microsoft.Extensions.Logging;
using System;
using System.Windows.Forms;

public class RichTextBoxLogger : ILogger
{
    private readonly RichTextBox _richTextBox;
    private readonly string _name;

    public RichTextBoxLogger(string name, RichTextBox richTextBox)
    {
        _name = name;
        _richTextBox = richTextBox;
    }
    public bool IsEnabled(LogLevel logLevel) => true;
    public IDisposable BeginScope<TState>(TState state) => null;

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    {
       

        string message = formatter(state, exception);


        _richTextBox.Invoke((Action)(() =>
        {
            _richTextBox.AppendText($"{message}\n");
            _richTextBox.ScrollToCaret();
        }));
    }
}

public class RichTextBoxLoggerConfiguration
{
    public LogLevel LogLevel { get; set; } = LogLevel.Information;
    public bool SingleLine { get; set; } = true;
}

public class RichTextBoxLoggerProvider : ILoggerProvider
{
    private readonly RichTextBox _richTextBox;

    public RichTextBoxLoggerProvider(RichTextBox richTextBox)
    {
        _richTextBox = richTextBox;
    }

    public ILogger CreateLogger(string categoryName)
    {
        return new RichTextBoxLogger(categoryName, _richTextBox);
    }

    public void Dispose() { }
}

public static class RichTextBoxLoggerExtensions
{
    public static ILoggingBuilder AddRichTextBox(this ILoggingBuilder builder, RichTextBox richTextBox)
    {
        builder.AddProvider(new RichTextBoxLoggerProvider(richTextBox));
        return builder;
    }
}
