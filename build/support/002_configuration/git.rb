configs ={
  :git => {
    :provider => 'github',
    :user => 'intellisysmay2014',
    :remotes => %w/mabreu14 adnanjt juanmcastillo gadielreyes 040mike Menyueru/,
    :repo => 'app' 
  }
}
configatron.configure_from_hash(configs)
