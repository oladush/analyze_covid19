file = "mft.txt"
keys = ["tray.exe"]

timelines = []

def parse_date(line, pad=0):
    return line[pad:pad+20]

with open(file, "rb") as df:
    log = df.read().decode("utf8").split('\n')

for i in range(len(log)):
    for key in keys:
        if key.lower() in log[i].lower():
            print(log[i])
            if parse_date(log[i]) not in timelines:
                timelines.append(parse_date(log[i], 60))

print("Time activity: ")
for i in range(len(timelines)):
    print(timelines[i])
