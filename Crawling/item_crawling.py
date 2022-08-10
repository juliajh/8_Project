import time
from selenium import webdriver
from selenium.webdriver.common.keys import Keys
from selenium.webdriver.common.by import By
from webdriver_manager.chrome import ChromeDriverManager
from selenium.webdriver.chrome.service import Service
from bs4 import BeautifulSoup
import requests

#db에서 정보 가져오기

def cutting(item, color):
    #db의 이름 split해서 이름만 가져오기
    #color 칼럼에서 색상 가져오기


def crowling(item, color):

    chrome_options = webdriver.ChromeOptions()
    chrome_options.add_experimental_option("detach", True)
    driver = webdriver.Chrome(service=Service(ChromeDriverManager().install()),options=chrome_options)
    driver.maximize_window()

    driver.get('https://search.shopping.naver.com/search/all?query={}'.format(item))
    time.sleep(2)

    if color == 'Y':
        driver.find_element_by_class_name('filter_color_128__24iKq').click()
        driver.find_element_by_class_name('filter_color_256__2LMHp').click()

        
