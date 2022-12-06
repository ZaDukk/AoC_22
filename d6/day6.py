with open("input.txt") as f:
    #inpt = [line for line in f.readlines()]
    inpt = f.read()

for char in range(len(inpt) - 4):
    if len(set(inpt[char:char+4])) == 4:
        print(char+4)
        break

for char in range(len(inpt) - 14):
    if len(set(inpt[char:char+14])) == 14:
        print(char+14) 
        break

