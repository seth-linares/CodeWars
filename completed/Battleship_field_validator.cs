/*
https://www.codewars.com/kata/52bb6539a4cf1b12d90005b7
*/



/*
    Implemented: error detection for incorrect tile placement of anything not on the edge

    Need to be implemented:
    - error detection for when tiles meet at the corner
    - ship counting
    - handling tiles on the rim 
    

    should counting be done by if(prev tile == 1) then add 1?
*/




namespace Code_Problems {
    using System;
    using System.Linq;
    using System.Collections.Generic;

  public class BattleshipField {
        public static bool ValidateBattlefield(int[,] field) {

            int rows = field.GetLength(0);
            int cols = field.GetLength(1);

            int length = 0;

            int battleships = 0;
            int cruisers = 0;
            int destroyers = 0;
            int submarines = 0;


            
            for(int i = 0; i < rows; i++) { 
                for(int j = 0; j < cols; j++) {
                    
                    int temp_j = j;
                    int temp_i = i;
                    

                    if(field[i,j] == 1) {
                        length++;


                        if(ship_validator() == false) {
                            return false;
                        }
                            

                        
                        if(j - 1 >= 0) {
                            if(field[i, j - 1] == 1) {
                                
                                while(j - 1 >= 0 && field[i, j - 1] == 1) {
                                    j--;
                                    if(ship_validator() == false) {
                                        return false;
                                    }
                                    if(field[i, j] == 1) {
                                        length++;
                                        field[i, j] = 2;
                                    }
                                        
                                    
                                }
                                i = temp_i;
                                j = temp_j;
                            }
                        }


                        if(j + 1 < cols) {
                            if(field[i, j + 1] == 1) {
                                
                                while(j + 1 < cols && field[i, j + 1] == 1) {
                                    j++;
                                    if(ship_validator() == false) {
                                        return false;
                                    }
                                    if(field[i, j] == 1) {
                                        length++;
                                        field[i, j] = 2;
                                    }
                                        
                                }

                                i = temp_i;
                                j = temp_j;

                                
                            }
                        }

                        if(i + 1 < rows) {
                            if(field[i + 1, j] == 1) {
                                while(i + 1 < rows && field[i + 1, j] == 1) {
                                    
                                    i++;
                                    if(ship_validator() == false) {
                                        return false;
                                    }
                                    if(field[i, j] == 1) {
                                        length++;
                                        field[i, j] = 2;

                                    }
                                }

                                i = temp_i;
                                j = temp_j;

                            }
                        }
                        
                        if(i - 1 >= 0) {
                            if(field[i - 1, j] == 1) {
                                while(i - 1 >= 0 && field[i - 1, j] == 1) {
                                    i--;
                                    if(ship_validator() == false) {
                                        return false;
                                    }
                                    if(field[i, j] == 1) {
                                        length++;
                                        field[i, j] = 2;
                                    }
                                }

                                i = temp_i;
                                j = temp_j;
                            }
                        }

                    }


                    bool length_validator() {
                        if(length > 4) {
                            return false;
                        }
                            

                        else if(length == 4)  {
                            battleships++;
                            if(battleships > 1) {
                                return false;
                            }
                                
                        }

                        else if(length == 3)  {
                            cruisers++;
                            if(cruisers > 2) {
                                return false;
                            }
                        }

                        else if(length == 2)  {
                            destroyers++;
                            if(destroyers > 3) {
                                return false;
                            }
                                
                        }

                        else if(length == 1)  {
                            submarines++;
                            if(submarines > 4) {
                                return false;
                            }
                        
                        }
                            


                        return true;
                    }

                    bool ship_validator() {
                        if(field[i, j] != 0) {
                            if(i + 1 < rows) {
                                if(j + 1 < cols) {
                                    if(field[i + 1,j + 1] != 0) {
                                        return false;
                                    }
                                }

                                if(j - 1 >= 0) {
                                    if(field[i + 1,j - 1] != 0) {
                                        return false;
                                    }
                                }
                            }

                            if(i - 1 >= 0) {
                                if(j + 1 < cols) {
                                    if(field[i - 1,j + 1] != 0) {
                                        return false;
                                    }
                                }

                                if(j - 1 >= 0) {
                                    if(field[i - 1,j - 1] != 0) {
                                        return false;
                                    }
                                }
                            }
                        }

                        return true;
                    }

                    

                    
                    if(length_validator() == false) {
                        return false;
                    }
                        
                    
                    length = 0;


        
                }
                
            }
            
            
            if(battleships != 1 || cruisers != 2 || destroyers != 3 || submarines != 4)
                return false;

            return true;
        }
    
       
    }
}