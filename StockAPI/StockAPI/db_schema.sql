create table STOCK_INFO (
	id INT,
	StockSymbol VARCHAR(50),
	Company VARCHAR(50)
);

create table STOCK_DATA (
	id INT,
	StockSymbolID INT,
	Date DATE,
	DayPriceOpen VARCHAR(50),
	DayPriceClose VARCHAR(50),
	MaxPriceSpan VARCHAR(50),
	MinPriceSpan VARCHAR(50),
	SpanPriceOpen VARCHAR(50),
	SpanPriceClose VARCHAR(50),
	Volume INT,
	ChangePercentage DECIMAL(3,2)
);
