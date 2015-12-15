//
//  ViewController.swift
//  zz
//
//  Created by 湯偉 on 2015/12/13.
//  Copyright © 2015年 湯偉. All rights reserved.
//

import UIKit

class ViewController: UIViewController {
    
    var ImageBool = false
    @IBOutlet weak var ImageButton: UIButton!
    @IBOutlet var iv: UIImageView!
    @IBAction func pictureViewButton(sender: AnyObject) {
        if !ImageBool {
            ImageBool = true
            iv.image = UIImage(named : "mouse.jpg")
            ImageButton.setTitle("不显示图片", forState: UIControlState.Normal)
        }
        else {
            ImageBool = false
            ImageButton.setTitle("显示图片", forState: UIControlState.Normal)
            iv.image = UIImage(named : "")
        }
        
    }
    
    override func viewDidLoad() {
        super.viewDidLoad()
        // Do any additional setup after loading the view, typically from a nib.
    }

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }


}

