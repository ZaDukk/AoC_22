with open("input.txt", "r") as f:
    inp = [line.strip() for line in f.readlines()]
p1Answer=0;



regX=[1]
for line in inp:
    if line[0] =="n":
        regX.append(regX[-1])
    else:

        regX+=[regX[-1],regX[-1]+int(line.split()[1])]
p1Answer = (sum([regX[19]*20,regX[59]*60,regX[99]*100,regX[139]*140,regX[179]*180,regX[219]*220]))     
        
print(f"Answer 1: {p1Answer}")
#part2

index=0
for y in range(6):
    for x in range(40):
        if x in [regX[index]-1,regX[index],regX[index]+1]:
            print("#",end="")
        else:
            print("-",end="")#used - instead of . because easier to read, though i still tried because i read the G as an S
        index+=1
    print() #this is slightly hard to read still 