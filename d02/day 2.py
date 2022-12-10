with open ("input.txt","r") as f:
    inp = [line.strip() for line in f.readlines()]

p1Answer =0;

for line in inp:
    totalScore=0;
    if line[2]=="X":
        totalScore+=1
        if line[0]=="A":
            totalScore+=3
        elif line[0] == "B":
            pass;
        else:
            totalScore+=6;
    elif line[2] =="Y":
        totalScore+=2
        if line[0] == "A":
            totalScore += 6
        elif line[0] == "B":
            totalScore+=3
        else:
            pass
    else:
        totalScore+=3
        if line[0]=="A":
            pass
        elif line[0] == "B":
            totalScore+=6
        else:
            totalScore+=3;
    p1Answer+=totalScore
#part2

p2_answer=0;
for line in inp:
    score=0;
    if line[2]=="Y":
        score+=3
        if line[0]=="A":
            score+=1
        elif line[0]=="B":
            score+=2
        else:
            score+=3
    elif line[2]=="X":
        if line[0]=="A":
            score+=3
        elif line[0]=="B":
            score+=1
        else:
            score+=2
    else:
        score+=6
        if line[0]=="A":
            score+=2
        elif line[0]=="B":
            score+=3
        else:
            score+=1
    p2_answer+=score




    pass

print(f"Part 1: {p1Answer}")
print(f"Part 2: {p2_answer}")