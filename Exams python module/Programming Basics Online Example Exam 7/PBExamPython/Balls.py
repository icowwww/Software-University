ballsCount = int(input())
ballsInformation = {
    "red": [lambda x : x + 5, 0],
    "orange": [lambda x : x + 10, 0],
    "yellow": [lambda x : x + 15, 0],
    "white": [lambda x : x + 20, 0],
    "black": [lambda x : int(x / 2), 0],
    "other": [lambda x : x, 0]
}
currPoints = 0
for i in range(ballsCount):
    currColour = input()
    currColour = "other" if currColour not in ballsInformation else currColour
    ballsInformation[currColour][1] += 1
    currPoints = ballsInformation[currColour][0](currPoints)

print(f'Total points: {currPoints}')
print(f'Red balls: {ballsInformation["red"][1]}')
print(f'Orange balls: {ballsInformation["orange"][1]}')
print(f'Yellow balls: {ballsInformation["yellow"][1]}')
print(f'White balls: {ballsInformation["white"][1]}')
print(f'Other colors picked: {ballsInformation["other"][1]}')
print(f'Divides from black balls: {ballsInformation["black"][1]}')
