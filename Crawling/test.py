import time
from selenium import webdriver
from selenium.webdriver.common.keys import Keys
from selenium.webdriver.common.by import By
from webdriver_manager.chrome import ChromeDriverManager
from selenium.webdriver.chrome.service import Service
from bs4 import BeautifulSoup
import requests

chrome_options = webdriver.ChromeOptions()
chrome_options.add_experimental_option("detach", True)
driver = webdriver.Chrome(service=Service(ChromeDriverManager().install()), options=chrome_options)
driver.maximize_window()

driver.get('https://search.shopping.naver.com/search/all?query=의자')
time.sleep(2)

driver.find_element(By.CLASS_NAME, 'filter_color_128__24iKq').click()
driver.find_element(By.CLASS_NAME, 'filter_color_256__2LMHp').click()
time.sleep(2)

img_url = driver.find_element(By.XPATH, '//*[@id="__next"]/div/div[2]/div[2]/div[3]/div[1]/ul/div/div[1]/li/div/div[1]/div/a/img').get_attribute('src')
price = driver.find_element(By.XPATH, '//*[@id="__next"]/div/div[2]/div[2]/div[3]/div[1]/ul/div/div[1]/li/div/div[2]/div[2]/strong/span/span').text
product_url = driver.find_element(By.XPATH, '//*[@id="__next"]/div/div[2]/div[2]/div[3]/div[1]/ul/div/div[1]/li/div/div[2]/div[1]/a').get_attribute('href')

print(img_url)
print(price)
print(product_url)


