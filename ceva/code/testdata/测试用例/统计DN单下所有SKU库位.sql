SELECT DnBin.bch_no, DnBin.dn_no, DnBin.bin_code, 
 sum(dnlin.qty) * skuinfo.volume,  bin.volume  
FROM DnBin
LEFT JOIN dnlin ON DnBin.dn_no = dnlin.dn_no
LEFT JOIN skuinfo ON dnlin.sku_no =  skuinfo.sku_no 
LEFT JOIN bin ON DnBin.bin_code = bin.bin_code
WHERE DnBin.dn_no = '9204838751' 
GROUP BY DnBin.bch_no, DnBin.dn_no, DnBin.bin_code,  bin.volume, skuinfo.volume
ORDER BY bin_code
