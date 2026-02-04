# Kata: Thinking & Testing : Something capitalized
# Link: https://www.codewars.com/kata/56d93f249c844788bc000002


# No Story

# No Description

# Only by Thinking and Testing

# Look at the results of the testcases, and guess the code!

# Tests:
# from solution import testit
# import codewars_test as test

# # return s.upper() ?
# @test.describe("testit")
# def testit_test():

#     @test.it("works for some examples")
#     def works_for_some_examples():
#         test.assert_equals(testit(""), "")
#         test.assert_equals(testit("a"), "A")
#         test.assert_equals(testit("b"), "B")
#         test.assert_equals(testit("a a"), "A A")
#         test.assert_equals(testit("a b"), "A B")
#         test.assert_equals(testit("a b c"), "A B C")

# 1st solution:


def testit(s):
    return " ".join(map(lambda s: s.capitalize(), s[::-1].lower().split()))[::-1]


# 2nd solution:
def testit(s):
    return " ".join(word.capitalize() for word in s[::-1].lower().split())[::-1]
