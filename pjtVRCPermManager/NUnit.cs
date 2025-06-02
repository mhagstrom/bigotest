using NUnit.Framework;
using System.Diagnostics;
using System.Text;
using pjtVRCPermManager;

[TestFixture]
public class PermManagerTests
{
    private MainForm mainForm;
    private StringBuilder performanceLog;
    private Stopwatch stopwatch;

    [OneTimeSetUp]
    public void Setup()
    {
        mainForm = new MainForm();
        performanceLog = new StringBuilder();
        stopwatch = new Stopwatch();
        
        performanceLog.AppendLine("Algorithm Performance Test Results");
        performanceLog.AppendLine("===============================");
        performanceLog.AppendLine($"Test Run: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
        performanceLog.AppendLine("---------------------------------------");
    }

    [OneTimeTearDown]
    public void Cleanup()
    {
        string fileName = $"AlgorithmPerformance_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.log";
        File.WriteAllText(fileName, performanceLog.ToString());
    }

    private void LogPerformance(string algorithm, string operationType, int dataSize, TimeSpan duration)
    {
        performanceLog.AppendLine($"Algorithm: {algorithm}");
        performanceLog.AppendLine($"Operation: {operationType}");
        performanceLog.AppendLine($"Data Size: {dataSize:N0} elements");
        performanceLog.AppendLine($"Duration: {duration.TotalMilliseconds:F2} ms");
        performanceLog.AppendLine($"Time per element: {(duration.TotalMilliseconds / dataSize):F6} ms");
        performanceLog.AppendLine("---------------------------------------");
    }

    [Test]
    [TestCase(100)]
    [TestCase(1000)]
    [TestCase(10000)]
    public void TestSearchPerformance(int dataSize)
    {
        // Generate test data
        var testUsers = Enumerable.Range(0, dataSize)
            .Select(i => $"TestUser_{i}")
            .ToList();
        foreach (var user in testUsers)
        {
            mainForm.TestGenerateUser(user);
        }

        // Test Linear Search
        stopwatch.Restart();
        var linearResults = mainForm.TestSearchUser("TestUser_" + (dataSize / 2), "Linear Search");
        stopwatch.Stop();
        LogPerformance("Linear Search", "Search", dataSize, stopwatch.Elapsed);

        // Test Binary Search
        stopwatch.Restart();
        var binaryResults = mainForm.TestSearchUser("TestUser_" + (dataSize / 2), "Binary Search");
        stopwatch.Stop();
        LogPerformance("Binary Search", "Search", dataSize, stopwatch.Elapsed);
    }

    [Test]
    [TestCase(100)]
    [TestCase(1000)]
    [TestCase(10000)]
    public void TestSortPerformance(int dataSize)
    {
        // Generate test data for each sort test to ensure fresh, unsorted data
        void PrepareTestData()
        {
            var random = new Random(42); // Consistent seed for reproducibility
            mainForm.ClearUsers();
            var testUsers = Enumerable.Range(0, dataSize)
                .Select(i => $"TestUser_{i}_{random.Next()}")  // Ensure uniqueness with index
                .ToList();
            foreach (var user in testUsers)
            {
                mainForm.TestGenerateUser(user);
            }
        }

        var random = new Random(42); // Fixed seed for reproducibility

        // Test Bubble Sort
        PrepareTestData();
        stopwatch.Restart();
        mainForm.TestSortUsers("Bubble Sort");
        stopwatch.Stop();
        LogPerformance("Bubble Sort", "Sort", dataSize, stopwatch.Elapsed);

        // Test Quick Sort
        PrepareTestData();
        stopwatch.Restart();
        mainForm.TestSortUsers("Quick Sort");
        stopwatch.Stop();
        LogPerformance("Quick Sort", "Sort", dataSize, stopwatch.Elapsed);

        // Test Merge Sort
        PrepareTestData();
        stopwatch.Restart();
        mainForm.TestSortUsers("Merge Sort");
        stopwatch.Stop();
        LogPerformance("Merge Sort", "Sort", dataSize, stopwatch.Elapsed);
    }
}