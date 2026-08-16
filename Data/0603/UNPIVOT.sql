SELECT Category, Quantity, Orderyear
FROM ##pivot1
UNPIVOT
(
    Quantity FOR [Orderyear] IN ([1996], [1997], [1998])
) AS unpvt