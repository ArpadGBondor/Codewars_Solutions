# Kata: Extract the domain name from a URL
# Link: https://www.codewars.com/kata/514a024011ea4fb54200004b

# Write a function that when given a URL as a string, parses out just the domain
# name and returns it as a string. For example:

# * url = "http://github.com/carbonfive/raygun" -> domain name = "github"
# * url = "http://www.zombie-bites.com"         -> domain name = "zombie-bites"
# * url = "https://www.cnet.com"                -> domain name = cnet"


def domain_name(url):
    # remove http
    if "http://" in url:
        url = url.replace("http://", "")
    # remove https
    if "https://" in url:
        url = url.replace("https://", "")

    # remove everything after first slash
    url = url.split("/")[0]

    subdomains = url.split(".")[::-1]

    # ignore root, let's pick next as default
    domain_name = subdomains[1]

    # let's take the most dominant (longest) subdomain as the domain name
    for s in subdomains[2::]:
        if len(s) > len(domain_name):
            domain_name = s

    return domain_name
