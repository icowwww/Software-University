priceList = {
    "90X130": {"price": 110, "discRanges": [60, 30], "discRates": [0.92, 0.95]},
    "100X150": {"price": 140, "discRanges": [80, 40], "discRates": [0.9, 0.94]},
    "130X180": {"price": 190, "discRanges": [50, 20], "discRates": [0.88, 0.93]},
    "200X300": {"price": 250, "discRanges": [50, 25], "discRates": [0.86, 0.91]}
}

joineryCount, joineryType, deliveryMethod = int(input()), input(), input()
currPrice, discRanges , discRates = priceList[joineryType].values()

if joineryCount < 10:
    print("Invalid order")
    exit()
elif joineryCount > discRanges[0]:
    currPrice *= discRates[0]
elif joineryCount > discRanges[1]:
    currPrice *= discRates[1]

fullPrice = currPrice * joineryCount
fullPrice = fullPrice + 60 if deliveryMethod == "With delivery" else fullPrice
fullPrice = fullPrice * 0.96 if joineryCount > 99 else fullPrice

print(f"{fullPrice:.2f} BGN")
