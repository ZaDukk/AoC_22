with open ("input.txt","r") as f:
    inp = [line.strip() for line in f.readlines()]

p1Answer =0;
p2Answer =0;
for line in inp:
    compartSize = int(len(line)/2)
    compart1=[]
    compart2 =[]
    for i in range (compartSize):
        compart1.append(line[i]);
    for i in range (compartSize, len(line)):
        compart2.append(line[i])
    common=list(set(compart1)&set(compart2));
    for i in common:
        if (ord(i) - 96) <0:
            p1Answer+=(ord(i) - 38)
        else:
            p1Answer+= (ord(i) - 96)


    pass

lineCount=1
comparts = []
for line in inp:

    if (lineCount==4):
        lineCount=1;
        print(comparts)
        common = list(set(comparts[0]) & set(comparts[1]) & set(comparts[2]))


        print(common)
        comparts = []
        for i in common:
            if (ord(i) - 96) < 0:
                p2Answer += (ord(i) - 38)
            else:
                p2Answer += (ord(i) - 96)
        comparts.append(line)
        lineCount+=1
    else:
        comparts.append(line)

        lineCount += 1

print(p1Answer)
print(p2Answer)#you need to add the final value manually 
