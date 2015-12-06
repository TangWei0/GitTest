//
//  main.swift
//  swift05
//
//  Created by 湯偉 on 2015/11/29.
//  Copyright © 2015年 湯偉. All rights reserved.
//

import Foundation

//1.判断运算符
var a = 3
var b = 4
//print(a == b ? "True" : "False")

//2.溢出运算符,数据运算超出取值范围，会报错。需添加溢出运算符 &
var c = UInt16.min
c = c &- 1
print("\(c)")