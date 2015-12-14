//
//  ViewController.swift
//  zz
//
//  Created by 湯偉 on 2015/12/13.
//  Copyright © 2015年 湯偉. All rights reserved.
//

import UIKit

class ViewController: UIViewController {
    
    
    @IBOutlet var iv: UIImageView!
    @IBAction func pictureViewButton(sender: AnyObject) {
        iv.image = UIImage(named : "mouse.jpg")
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

