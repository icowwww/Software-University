first_number = input()
second_number = input()
result = ""

for currNumber in range(int(first_number), int(second_number) + 1):
    strNumber = str(currNumber)
    passes = True
    for i in range(0,4):
        if int(strNumber[i]) % 2 == 0 or int(strNumber[i]) not in range(int(first_number[i]), int(second_number[i]) + 1):
            passes = False
            break
    result += strNumber + " " if passes else ""
print(result.rstrip())
