using Xunit;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Infrastructure.Data;
using Library.ApplicationCore.Entities;

namespace Library.UnitTests.Infrastructure.JsonLoanRepositoryTests;

public class GetLoan
{
	// Substitute for the IJsonData dependency
	private readonly IJsonData _jsonData;
	// System under test
	private readonly JsonLoanRepository _sut;

	public GetLoan()
	{
		_jsonData = Substitute.For<IJsonData>();
		_sut = new JsonLoanRepository(_jsonData);
	}

	[Fact(DisplayName = "JsonLoanRepository.GetLoan: Returns populated loan when loan exists")]
	public async Task GetLoan_ReturnsPopulatedLoan_WhenLoanExists()
	{
		// arrange
		var id = 42;
		var stored = new Loan
		{
			Id = id,
			BookItemId = 1,
			PatronId = 2,
			LoanDate = new DateTime(2020,1,1),
			DueDate = new DateTime(2020,2,1)
		};
		var populated = new Loan
		{
			Id = id,
			BookItemId = stored.BookItemId,
			PatronId = stored.PatronId,
			LoanDate = stored.LoanDate,
			DueDate = stored.DueDate,
			ReturnDate = new DateTime(2020,2,2)
		};

		_jsonData.EnsureDataLoaded().Returns(Task.CompletedTask);
		_jsonData.Loans.Returns(new List<Loan> { stored });
		_jsonData.GetPopulatedLoan(Arg.Is<Loan>(l => l.Id == id)).Returns(populated);

		// act
		var result = await _sut.GetLoan(id);

		// assert
		Assert.NotNull(result);
		Assert.Equal(populated.Id, result!.Id);
		Assert.Equal(populated.ReturnDate, result.ReturnDate);
		await _jsonData.Received(1).EnsureDataLoaded();
	}

    [Fact(DisplayName = "JsonLoanRepository.GetLoan: Returns null when loan does not exist")]
    public async Task GetLoan_ReturnsNull_WhenLoanDoesNotExist()
    {
        // arrange
        var id = 99;
        var stored = new Loan
        {
            Id = 1,
            BookItemId = 1,
            PatronId = 2,
            LoanDate = new DateTime(2020,1,1),
            DueDate = new DateTime(2020,2,1)
        };

        _jsonData.EnsureDataLoaded().Returns(Task.CompletedTask);
        _jsonData.Loans.Returns(new List<Loan> { stored });

        // act
        var result = await _sut.GetLoan(id);

        // assert
        Assert.Null(result);
        await _jsonData.Received(1).EnsureDataLoaded();
        _jsonData.DidNotReceive().GetPopulatedLoan(Arg.Any<Loan>());
    }
}
