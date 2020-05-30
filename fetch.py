import urllib.request
import json
def fetch_price(currency, interval): #should run on a seperate thread
    url = "https://api.coindesk.com/v1/bpi/currentprice.json"
    response = urllib.request.urlopen(url)
    output = json.loads(response.read())
      #gbp is 0 usd is 1 eur is 2
    price_gbp = output["bpi"].get("GBP").get("rate_float")
    price_usd = output["bpi"].get("USD").get("rate_float")
    price_eur = output["bpi"].get("EUR").get("rate_float")
    return price_usd, price_gbp, price_eur

prices = fetch_price(1, 1)

print(str(prices))

