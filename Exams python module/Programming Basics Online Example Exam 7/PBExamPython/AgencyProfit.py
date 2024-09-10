airline = input()
adultTicketsCount = int(input())
kidTicketsCount = int(input())
adultTicketPrice = float(input())
kidTicketPrice = adultTicketPrice * 0.3
tax = float(input())

totalFromTickets = adultTicketPrice * adultTicketsCount + kidTicketPrice * kidTicketsCount
totalFromTaxes = adultTicketsCount * tax + kidTicketsCount * tax
totalRevenue = totalFromTickets + totalFromTaxes
agencyProfit = totalRevenue * 0.2

print(f"The profit of your agency from {airline} tickets is {agencyProfit:.2f} lv.")
