fullBaggageTax = float(input())
currBaggageKg = float(input())
daysLeft = int(input())
baggageCount = int(input())

currBaggageTax = fullBaggageTax
if currBaggageKg < 10:
    currBaggageTax = fullBaggageTax * 0.2
elif currBaggageKg <= 20:
    currBaggageTax = fullBaggageTax * 0.5

if daysLeft < 7:
    currBaggageTax *= 1.4
elif daysLeft <= 30:
    currBaggageTax *= 1.15
else:
    currBaggageTax *= 1.1

baggageTaxSum = currBaggageTax * baggageCount
print(f"The total price of bags is: {baggageTaxSum:.2f} lv.")
