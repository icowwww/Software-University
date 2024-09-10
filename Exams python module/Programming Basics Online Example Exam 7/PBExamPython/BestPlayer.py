currPlayerName = input()
maxGoals = -1
topGoalScorer = ""

while currPlayerName != "END":
    goals = int(input())
    if goals > maxGoals:
        maxGoals = goals
        topGoalScorer = currPlayerName

    if maxGoals >= 10:
        break
    currPlayerName = input()

print(f'{topGoalScorer} is the best player!')
if maxGoals >= 3:
    print(f'He has scored {maxGoals} goals and made a hat-trick !!!')
else:
    print(f'He has scored {maxGoals} goals.')
