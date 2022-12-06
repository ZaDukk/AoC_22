def fully_intersect(a, b, c, d):
    return a <= c <= d <= b or c <= a <= b <= d


def intersect(a, b, c, d):
    return a <= c <= b or c <= a <= d


def part_1(arr):
    soloution = 0
    for group in arr:
        a, b = group[0]
        c, d = group[1]
        if fully_intersect(a, b, c, d):
            soloution += 1

    return soloution


def part_2(arr):
    soloution = 0
    for group in arr:
        a, b = group[0]
        c, d = group[1]
        if intersect(a, b, c, d):
            soloution += 1

    return soloution


###main####
with open('input.txt') as f:
    arr = []
    for line in f.readlines():
        group = []
        for interval in line.strip().split(','):
            group.append(list(map(int, interval.split('-'))))
        arr.append(group)

    print('Part 1:', part_1(arr))
    print('Part 2:', part_2(arr))