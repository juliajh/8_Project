import requests
import json
import schedule
import time
import re

item_dict = {'Chair': '의자', 'Sofa': '소파', 'Bed': '이불', 'Stand': '스탠드', 'BookShelf': '책장', 'Desk': '책상',
             'FlowerPot:꽃병', 'PhotoFrame:액자'}
color_dict = {'Yellow': '노란색', 'Blue': '파란색', 'Green':'초록색', 'White':'흰색', 'Red':'빨간색', 'Brown':'갈색'}

def item_info(item_name, color_type):
    client_id = 'bdpWYU7e70Thq9gFsYAU'
    client_secret = '9JU2hmkHTD'

    item_dict = {'Chair': '의자', 'Sofa': '소파', 'Bed': '이불', 'Stand':'스탠드', 'BookShelf':'책장','Desk':'책상', 'FlowerPot:꽃병','PhotoFrame:액자'}
    color_dict = {'Yellow': '노란색', 'Blue': '파란색', 'Green':'초록색', 'White':'흰색', 'Red':'빨간색', 'Brown':'갈색'}
    item_color = f"{item_dict[item_name]} {color_dict[color_type]}"
    name = item_name +'_'+ color_type

    naver_open_api = 'https://openapi.naver.com/v1/search/shop.json?query=' + item_color
    header_params = {"X-Naver-Client-Id":client_id, "X-Naver-Client-Secret":client_secret}
    res = requests.get(naver_open_api, headers=header_params)

    item_information = []
    if res.status_code == 200:
        data = res.json()
        for index, item in enumerate(data['items']):
            item_tmp = {}
            item_tmp['Category'] = item_name
            item_tmp['Color'] = color_type
            item_tmp['Title'] = re.sub(r'[0-9|<|>|b|\/]+', '', item['title'])
            item_tmp['Link'] = item['link']
            item_tmp['Image'] = item['image']
            item_tmp['Price'] = item['lprice']
            item_tmp['Brand'] = item['brand']
            item_tmp['Price'] = item['lprice']
            item_information.append(item_tmp)
            if index >= 5:
                break
    else:
        print ("Error Code:", res.status_code)

    print(item_information)
    with open('.\\data\\{}.json'.format(name), 'w', encoding='utf-8') as file:
        json.dump(item_information, file, ensure_ascii=False, indent='\t')
def make_Json():
    for i in item_dict.keys():
        for j in color_dict.keys():
            item_info(i,j)
    print('end of save')