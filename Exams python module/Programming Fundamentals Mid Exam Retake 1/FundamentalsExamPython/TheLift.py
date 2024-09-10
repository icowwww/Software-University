def loadPeople(wagonsStatus, peopleCount):
    for wagon in range(len(wagonsStatus)):
        if wagonsStatus[wagon] != 4:
            currPeopleLoading = min(4 - wagonsStatus[wagon], peopleCount)
            wagonsStatus[wagon] += currPeopleLoading
            peopleCount -= currPeopleLoading
    return wagonsStatus, peopleCount

peopleCount = int(input())
wagonsStatus = [int(x) for x in input().split()]
wagonsStatus, peopleCount = loadPeople(wagonsStatus, peopleCount)
allWagonsFull = all(wagon == 4 for wagon in wagonsStatus)
result = "The lift has empty spots!\n" if not allWagonsFull else (f"There isn't enough space! {peopleCount} people in a queue!\n" if peopleCount != 0  else "")
result += f"{' '.join(map(str, wagonsStatus))}"
print(result)
