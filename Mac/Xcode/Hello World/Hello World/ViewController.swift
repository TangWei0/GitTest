//
//  ViewController.swift
//  Hello World
//
//  Created by 湯偉 on 2017/02/04.
//  Copyright © 2017年 湯偉. All rights reserved.
//

import UIKit

class ViewController: UIViewController {

    override func viewDidLoad() {
        super.viewDidLoad()
        // Do any additional setup after loading the view, typically from a nib.
    }

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    @IBOutlet weak var SegmentedControl: UISegmentedControl!

    @IBOutlet weak var TextLabel: UILabel!
    
    @IBAction func LabelChange(_ sender: UISegmentedControl) {
        switch SegmentedControl.selectedSegmentIndex {
        case 0:
            TextLabel.text = "我爱妈妈";
        case 1:
            TextLabel.text = "我爱👶";
        case 2:
            TextLabel.text = "我爱爸爸妈妈";
        default:
            break;
        }
    }
}

