from networkx import DiGraph, shortest_path # saved me so hard today
#import matplotlib.pyplot as plt {this was for trying to plot the graph beacuse i thought it would look cool, may do this later }


cardinals = [(0, -1), (0, 1), (-1, 0), (1, 0)]

inp = open("input.txt").read()
# find start and end
S = inp.find("S")
E = inp.find("E")
inp = inp.replace("S", "a").replace("E", "z")

# make the letters numbers 
g = [[ord(c)-97 for c in line] for line in inp.split("\n")]

#print(g)

startPointX, startPointY = S % (len(g[0]) + 1), S // (len(g[0])+1)
targetX, targetY = E % (len(g[0]) + 1), E // (len(g[0])+1)

heatmap = DiGraph()

for y in range(len(g)):
    for x in range(len(g[0])):
        for direction in cardinals:
            newX = x + direction[0]
            newY = y + direction[1]
            # checking validiy
            if newX in range(len(g[0])) and newY in range(len(g)):
                startNode = g[y][x]
                endNode = g[newY][newX]
                # checking if the edge exists in the graph
                if startNode+1 >= endNode:
                    heatmap.add_edge((x, y), (newX, newY))

p = shortest_path(heatmap, (startPointX, startPointY), (targetX, targetY))
print(f"{len(p) - 1}")


##part2##

minimum = float("inf")
# try all starts with "a"
for y in range(len(g)):
    for x in range(len(g[0])):
        if g[y][x] == 0:
            try:
                minimum = min(minimum, len(shortest_path(heatmap, (x, y), (targetX, targetY))) - 1)
            except:
                pass
##you can make part 2 run much faster by doing it in reverse and starting at the end point (first one you reach is the minimum)
print(minimum)