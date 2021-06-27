const assert = require("chai").assert;

describe("getBalanceInPeriodByCategory()", function() {
  it("returns 0 if there are no transactions", function() {
    assert.equal(
      getBalanceInPeriodByCategory(
        [],
        "groceries",
        new Date("2018-03-01"),
        new Date("2018-03-31")
      ),
      0
    );
  });
  // add your tests here
  
    it("returns 1000, category ", function() {
    assert.equal(
      getBalanceInPeriodByCategory(
        [          
          {
            id: 123,
            sourceAccount: 'my_account',
            targetAccount: 'coffee_shop',
            amount: 1000,
            category: 'groceries',
            time: '2018-03-12T12:34:00Z'
          },
           {
            id: 123,
            sourceAccount: 'my_account',
            targetAccount: 'coffee_shop',
            amount: 800,
            category: 'eating_out',
          time: '2018-03-12T12:34:00Z'
          }
        ],
        "groceries",
        new Date("2018-03-01"),
        new Date("2018-03-31")
      ),
      1000
    );
  });
  
   it("returns -800, category eating_out", function() {
    assert.equal(
      getBalanceInPeriodByCategory(
        [          
          {
            id: 123,
            sourceAccount: 'my_account',
            targetAccount: 'coffee_shop',
            amount: 1000,
            category: 'groceries',
          time: '2018-03-12T12:34:00Z'
          },
           {
            id: 123,
            sourceAccount: 'my_account',
            targetAccount: 'coffee_shop',
            amount: -800,
            category: 'eating_out',
          time: '2018-03-12T12:34:00Z'
          }
        ],
        "eating_out",
        new Date("2018-03-01"),
        new Date("2018-03-31")
      ),
      -800
    );
  });
  
    it("returns 200.11, category eating_out, checking decimal inputs", function() {
    assert.equal(
      getBalanceInPeriodByCategory(
        [          
          {
            id: 123,
            sourceAccount: 'my_account',
            targetAccount: 'coffee_shop',
            amount: 1000.11,
            category: 'eating_out',
          time: '2018-03-12T12:34:00Z'
          },
           {
            id: 123,
            sourceAccount: 'my_account',
            targetAccount: 'coffee_shop',
            amount: -800,
            category: 'eating_out',
          time: '2018-03-12T12:34:00Z'
          }
        ],
        "eating_out",
        new Date("2018-03-01"),
        new Date("2018-03-31")
      ),
      200.11
    );
  });
  
    it("returns 0, category eating_out", function() {
    assert.equal(
      getBalanceInPeriodByCategory(
        [          
          {
            id: 123,
            sourceAccount: 'my_account',
            targetAccount: 'coffee_shop',
            amount: 800.123456,
            category: 'eating_out',
          time: '2018-03-12T12:34:00Z'
          },
           {
            id: 123,
            sourceAccount: 'my_account',
            targetAccount: 'coffee_shop',
            amount: -800.123456,
            category: 'eating_out',
          time: '2018-03-12T12:34:00Z'
          }
        ],
        "eating_out",
        new Date("2018-03-01"),
        new Date("2018-03-31")
      ),
      0.000000000
    );
  });
  
    it("returns 0, items out of date", function() {
    assert.equal(
      getBalanceInPeriodByCategory(
        [          
          {
            id: 123,
            sourceAccount: 'my_account',
            targetAccount: 'coffee_shop',
            amount: 1000,
            category: 'eating_out',
          time: '2019-03-12T12:34:00Z'
          },
           {
            id: 123,
            sourceAccount: 'my_account',
            targetAccount: 'coffee_shop',
            amount: 2000,
            category: 'eating_out',
          time: '2018-04-12T12:34:00Z'
          }
        ],
        "eating_out",
        new Date("2018-03-01"),
        new Date("2018-03-31")
      ),
      0.000000000
    );
  });  

  
});