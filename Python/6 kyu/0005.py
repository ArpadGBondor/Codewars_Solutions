# Kata: Simple time difference
# Link: https://www.codewars.com/kata/5b76a34ff71e5de9db0000f2

# In this Kata, you will be given a series of times at which an alarm sounds.
# Your task will be to determine the maximum time interval between alarms. Each
# alarm starts ringing at the beginning of the corresponding minute and rings
# for exactly one minute. The times in the array are not in chronological order.
# Ignore duplicate times, if any.

# Examples:

# ["14:51"] --> "23:59"
# If the alarm sounds now, it will not sound for another 23 hours and 59 minutes.

# ["23:00","04:22","18:05","06:24"] --> "11:40"
# The alarm sounds 4 times in a day. The max interval that the alarm will not
# sound is 11 hours and 40 minutes.

# More examples in test cases. Good luck!


def solve(arr):
    # Convert each time string ("HH:MM") into total minutes since 00:00
    minutes_arr: list[int] = list(map(time_to_number, arr))

    # Sort times so we can measure gaps between consecutive times
    minutes_arr.sort()

    # Add the first time again but shifted by 24 hours (1440 minutes)
    # This allows us to measure the overnight gap (last → first across midnight)
    minutes_arr.append(minutes_arr[0] + 24 * 60)

    diff: int = 0  # Will store the largest gap (in minutes)
    i: int = 0

    while i < len(minutes_arr) - 1:
        # Gap between two times minus 1 minute (problem-specific requirement)
        gap = minutes_arr[i + 1] - minutes_arr[i] - 1

        # Keep the maximum gap found so far
        if gap > diff:
            diff = gap

        i += 1

    # Convert the result back into "HH:MM" format
    return number_to_time(diff)


def time_to_number(s: str) -> int:
    # Split "HH:MM" into hours and minutes
    time: list[str] = s.split(":")

    # Convert to total minutes
    return int(time[0]) * 60 + int(time[1])


def number_to_time(n: int) -> str:
    # Convert total minutes back into hours and minutes
    hour = n // 60
    minute = n % 60

    # Format with leading zeros (e.g., 03:07)
    return f"{hour:02}:{minute:02}"


# I used AI to generate comments, not the code itself.
