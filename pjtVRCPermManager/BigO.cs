using System.Diagnostics;
using NUnit.Framework;
using System.Text;

namespace pjtVRCPermManager;

[TestFixture]
public class BigO
{
    private MainForm _mainForm;
    private const string LogFilePath = "performance_log.csv";
    private Stopwatch _stopwatch;

    [OneTimeSetUp]
    public void Setup()
    {
        _mainForm = new MainForm();
        _stopwatch = new Stopwatch();
        
        // Create CSV header
        File.WriteAllText(LogFilePath, 
            "Operation,InputSize,TimeTakenMs,ItemsFound\n");
    }

    [Test]
    public void TestSearchPerformance([Values(100, 1000, 10000)] int userCount)
    {
        // Setup test data
        _mainForm.ClearUsers();
        for (int i = 0; i < userCount; i++)
        {
            _mainForm.TestGenerateUser($"User_{i}");
        }

        // Test searching for permissions by username
        string targetUsername = $"User_{userCount / 2}"; // Search for middle user
        
        // Linear Search
        _stopwatch.Restart();
        var linearResults = _mainForm.TestSearchUser(targetUsername, "Linear Search");
        _stopwatch.Stop();
        LogPerformance("LinearSearch", userCount, _stopwatch.ElapsedMilliseconds, linearResults.Count);

        // Binary Search
        _stopwatch.Restart();
        var binaryResults = _mainForm.TestSearchUser(targetUsername, "Binary Search");
        _stopwatch.Stop();
        LogPerformance("BinarySearch", userCount, _stopwatch.ElapsedMilliseconds, binaryResults.Count);
    }

    [Test]
    public void TestSortPerformance([Values(100, 1000, 10000)] int userCount)
    {
        // Setup test data
        _mainForm.ClearUsers();
        for (int i = 0; i < userCount; i++)
        {
            _mainForm.TestGenerateUser($"User_{userCount - i}"); // Add in reverse order for worst case
        }

        // Test each sort method
        string[] sortMethods = { "Bubble Sort", "Quick Sort", "Merge Sort" };
        
        foreach (var sortMethod in sortMethods)
        {
            _stopwatch.Restart();
            _mainForm.TestSortUsers(sortMethod);
            _stopwatch.Stop();
            LogPerformance(sortMethod, userCount, _stopwatch.ElapsedMilliseconds, userCount);
        }
    }

    private void LogPerformance(string operation, int inputSize, long timeTakenMs, int itemsFound)
    {
        string logEntry = $"{operation},{inputSize},{timeTakenMs},{itemsFound}\n";
        File.AppendAllText(LogFilePath, logEntry);
    }

    [OneTimeTearDown]
    public void Cleanup()
    {
        _mainForm.Dispose();
    }
}