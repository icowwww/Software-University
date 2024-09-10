currInput = input()
currTotalPrice = 0.0

while currInput != "special" and currInput != "regular":
    currPrice = float(currInput)
    if currPrice <= 0:
        print("Invalid price!")
        currInput = input()
        continue
    currTotalPrice += currPrice
    currInput = input()
if currTotalPrice <= 0:
    print("Invalid order!")
    exit()
totalTaxes = currTotalPrice * 0.20
totalPrice = currTotalPrice + totalTaxes
if currInput == "special":
    totalPrice *= 0.90

print("Congratulations you've just bought a new computer!")
print(f"Price without taxes: {currTotalPrice:.2f}$")
print(f"Taxes: {totalTaxes:.2f}$")
print("-----------")
print(f"Total price: {totalPrice:.2f}$")
