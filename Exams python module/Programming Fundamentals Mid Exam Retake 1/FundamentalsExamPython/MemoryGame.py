elements = input().split()
currInput = input()
moves = 0
result = []

while currInput != "end":
    indexes = currInput.split()
    moves += 1
    firstIndex, secondIndex = int(indexes[0]), int(indexes[1])
    if 0 <= firstIndex < len(elements) and 0 <= secondIndex < len(elements) and firstIndex != secondIndex:
        if elements[firstIndex] != elements[secondIndex]:
            result.append("Try again!")
            currInput = input()
            continue
        matchingElement = elements[firstIndex]
        lowerIndex, higherIndex = min(firstIndex,secondIndex), max(firstIndex,secondIndex)
        del elements[lowerIndex]
        del elements[higherIndex - 1]
        result.append(f"Congrats! You have found matching elements - {matchingElement}!")
    else:
        result.append("Invalid input! Adding additional elements to the board")
        middleIndex = len(elements) // 2
        elementToInput = f"-{moves}a"
        elements[middleIndex:middleIndex] =[elementToInput, elementToInput]
    if not elements:
        result.append(f"You have won in {moves} turns!")
        break
    currInput = input()
if elements:
        result.append(f"Sorry you lose :(\n{' '.join(elements)}")
print('\n'.join(result))
