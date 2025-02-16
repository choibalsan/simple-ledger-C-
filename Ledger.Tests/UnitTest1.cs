using Moq;
using simple_ledger_C_.Models;

[TestClass]
public class LedgerRepositoryTests
{
    private Mock<ITransactionService> _mockTransactionService;
    private Mock<IBalanceService> _mockBalanceService;
    private ILedgerRepository _ledgerRepository;

    [TestInitialize]
    public void Setup()
    {
        _mockTransactionService = new Mock<ITransactionService>();
        _mockBalanceService = new Mock<IBalanceService>();
        _ledgerRepository = new LedgerRepository(_mockTransactionService.Object, _mockBalanceService.Object);
    }

    [TestMethod]
    public void RecordTransaction_Positive_ShouldCallServicesCorrectly()
    {
        // Arrange
        var amount = 100m; // deposit
        var userId = "user1";

        // Act
        _ledgerRepository.RecordTransaction(amount, userId);

        // Assert
        _mockTransactionService.Verify(s => s.RecordTransaction(It.Is<AccountTransaction>(t => t.Amount == amount), userId), Times.Once);
        _mockBalanceService.Verify(s => s.UpdateBalance(userId, amount), Times.Once);
    }

    [TestMethod]
    public void RecordTransaction_Negative_ShouldCallServicesCorrectly()
    {
        // Arrange
        var amount = -50m; // withdrawal
        var userId = "user1";

        // Act
        _ledgerRepository.RecordTransaction(amount, userId);

        // Assert
        _mockTransactionService.Verify(s => s.RecordTransaction(It.Is<AccountTransaction>(t => t.Amount == amount), userId), Times.Once);
        _mockBalanceService.Verify(s => s.UpdateBalance(userId, amount), Times.Once);
    }

    [TestMethod]
    public void GetBalance_ShouldReturnValueFromBalanceService()
    {
        // Arrange
        var userId = "user1";
        _mockBalanceService.Setup(s => s.GetBalance(userId)).Returns(200m);

        // Act
        var result = _ledgerRepository.GetBalance(userId);

        // Assert
        Assert.AreEqual(200m, result);
    }

    [TestMethod]
    public void GetTransactions_ShouldReturnTransactionsFromTransactionService()
    {
        // Arrange
        var userId = "user1";
        var txList = new List<AccountTransaction> { new AccountTransaction(100m), new AccountTransaction(-50m) };
        _mockTransactionService.Setup(s => s.GetTransactions(userId)).Returns(txList);

        // Act
        var result = _ledgerRepository.GetTransactions(userId);

        // Assert
        CollectionAssert.AreEquivalent(txList, result.ToList());
    }
}
