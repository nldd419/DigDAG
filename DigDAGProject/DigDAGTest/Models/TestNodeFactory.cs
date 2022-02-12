using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigDAGTest.Models
{
    internal static class TestNodeFactory
    {
        public static TestNode CreateTree()
        {
            /*
             * [0]
             *  |____________
             *  |            |
             * [1]          [2]
             *  |_____       |_______
             *  |     |      |       |
             * [3]   [4]    [5]     [6]
             *  |__   |__    |___    |___
             *  |  |  |  |   |   |   |   |
             * [7][8][9][10][11][12][13][14]
             */

            var node0 = new TestNode(0);
            var node1 = new TestNode(1);
            var node2 = new TestNode(2);
            var node3 = new TestNode(3);
            var node4 = new TestNode(4);
            var node5 = new TestNode(5);
            var node6 = new TestNode(6);
            var node7 = new TestNode(7);
            var node8 = new TestNode(8);
            var node9 = new TestNode(9);
            var node10 = new TestNode(10);
            var node11 = new TestNode(11);
            var node12 = new TestNode(12);
            var node13 = new TestNode(13);
            var node14 = new TestNode(14);

            node0.AddChild(node1);
            node0.AddChild(node2);

            node1.AddChild(node3);
            node1.AddChild(node4);

            node2.AddChild(node5);
            node2.AddChild(node6);

            node3.AddChild(node7);
            node3.AddChild(node8);

            node4.AddChild(node9);
            node4.AddChild(node10);

            node5.AddChild(node11);
            node5.AddChild(node12);

            node6.AddChild(node13);
            node6.AddChild(node14);

            return node0;
        }

        public static TestNode CreateLeftDeepTree()
        {
            /*
             * [0]
             *  |____________
             *  |            |
             * [1]          [2]
             *  |_____       |_______
             *  |     |      |       |
             * [3]   [4]    [5]     [6]
             *  |__   |__    |___    |___
             *  |  |  |  |   |   |   |   |
             * [7][8][9][10][11][12][13][14]
             *  |     |      |       |
             *  |     |      |       |
             * [15]  [16]   [17]    [18]
             */

            var node0 = new TestNode(0);
            var node1 = new TestNode(1);
            var node2 = new TestNode(2);
            var node3 = new TestNode(3);
            var node4 = new TestNode(4);
            var node5 = new TestNode(5);
            var node6 = new TestNode(6);
            var node7 = new TestNode(7);
            var node8 = new TestNode(8);
            var node9 = new TestNode(9);
            var node10 = new TestNode(10);
            var node11 = new TestNode(11);
            var node12 = new TestNode(12);
            var node13 = new TestNode(13);
            var node14 = new TestNode(14);
            var node15 = new TestNode(15);
            var node16 = new TestNode(16);
            var node17 = new TestNode(17);
            var node18 = new TestNode(18);

            node0.AddChild(node1);
            node0.AddChild(node2);

            node1.AddChild(node3);
            node1.AddChild(node4);

            node2.AddChild(node5);
            node2.AddChild(node6);

            node3.AddChild(node7);
            node3.AddChild(node8);

            node4.AddChild(node9);
            node4.AddChild(node10);

            node5.AddChild(node11);
            node5.AddChild(node12);

            node6.AddChild(node13);
            node6.AddChild(node14);

            node7.AddChild(node15);

            node9.AddChild(node16);

            node11.AddChild(node17);

            node13.AddChild(node18);

            return node0;
        }

        public static TestNode CreateRightDeepTree()
        {
            /*
             * [0]
             *  |____________
             *  |            |
             * [1]          [2]
             *  |_____       |_______
             *  |     |      |       |
             * [3]   [4]    [5]     [6]
             *  |__   |__    |___    |___
             *  |  |  |  |   |   |   |   |
             * [7][8][9][10][11][12][13][14]
             *     |     |       |       |
             *     |     |       |       |
             *    [15]  [16]    [17]    [18]
             */

            var node0 = new TestNode(0);
            var node1 = new TestNode(1);
            var node2 = new TestNode(2);
            var node3 = new TestNode(3);
            var node4 = new TestNode(4);
            var node5 = new TestNode(5);
            var node6 = new TestNode(6);
            var node7 = new TestNode(7);
            var node8 = new TestNode(8);
            var node9 = new TestNode(9);
            var node10 = new TestNode(10);
            var node11 = new TestNode(11);
            var node12 = new TestNode(12);
            var node13 = new TestNode(13);
            var node14 = new TestNode(14);
            var node15 = new TestNode(15);
            var node16 = new TestNode(16);
            var node17 = new TestNode(17);
            var node18 = new TestNode(18);

            node0.AddChild(node1);
            node0.AddChild(node2);

            node1.AddChild(node3);
            node1.AddChild(node4);

            node2.AddChild(node5);
            node2.AddChild(node6);

            node3.AddChild(node7);
            node3.AddChild(node8);

            node4.AddChild(node9);
            node4.AddChild(node10);

            node5.AddChild(node11);
            node5.AddChild(node12);

            node6.AddChild(node13);
            node6.AddChild(node14);

            node8.AddChild(node15);

            node10.AddChild(node16);

            node12.AddChild(node17);

            node14.AddChild(node18);

            return node0;
        }

        public static TestNode CreateBothSidesDeepTree()
        {
            /*
             * [0]
             *  |_______________
             *  |               |
             * [1]             [2]
             *  |_______        |_______
             *  |       |       |       |
             * [3]     [4]     [5]     [6]
             *  |___    |___    |___    |___
             *  |   |   |   |   |   |   |   |
             * [7] [8] [9] [10][11][12][13][14]
             *  |   |   |           |   |   |
             *  |   |   |           |   |   |
             * [15][16][17]        [18][19][20]
             *  |   |                   |   |
             *  |   |                   |   |
             * [21][22]                [23][24]
             *  |                           |
             *  |                           |
             * [25]                        [26]
             */

            var node0 = new TestNode(0);
            var node1 = new TestNode(1);
            var node2 = new TestNode(2);
            var node3 = new TestNode(3);
            var node4 = new TestNode(4);
            var node5 = new TestNode(5);
            var node6 = new TestNode(6);
            var node7 = new TestNode(7);
            var node8 = new TestNode(8);
            var node9 = new TestNode(9);
            var node10 = new TestNode(10);
            var node11 = new TestNode(11);
            var node12 = new TestNode(12);
            var node13 = new TestNode(13);
            var node14 = new TestNode(14);
            var node15 = new TestNode(15);
            var node16 = new TestNode(16);
            var node17 = new TestNode(17);
            var node18 = new TestNode(18);
            var node19 = new TestNode(19);
            var node20 = new TestNode(20);
            var node21 = new TestNode(21);
            var node22 = new TestNode(22);
            var node23 = new TestNode(23);
            var node24 = new TestNode(24);
            var node25 = new TestNode(25);
            var node26 = new TestNode(26);

            node0.AddChild(node1);
            node0.AddChild(node2);

            node1.AddChild(node3);
            node1.AddChild(node4);

            node2.AddChild(node5);
            node2.AddChild(node6);

            node3.AddChild(node7);
            node3.AddChild(node8);

            node4.AddChild(node9);
            node4.AddChild(node10);

            node5.AddChild(node11);
            node5.AddChild(node12);

            node6.AddChild(node13);
            node6.AddChild(node14);

            node7.AddChild(node15);

            node8.AddChild(node16);

            node9.AddChild(node17);

            node12.AddChild(node18);

            node13.AddChild(node19);

            node14.AddChild(node20);

            node15.AddChild(node21);

            node16.AddChild(node22);

            node19.AddChild(node23);

            node20.AddChild(node24);

            node21.AddChild(node25);

            node24.AddChild(node26);

            return node0;
        }
        
        public static TestNode CreateCenterDeepTree()
        {
            /*
             * [0]
             *  |_______________
             *  |               |
             * [1]             [2]
             *  |_______        |_______
             *  |       |       |       |
             * [3]     [4]     [5]     [6]
             *  |___    |___    |___    |___
             *  |   |   |   |   |   |   |   |
             * [7] [8] [9] [10][11][12][13][14]
             *      |   |   |   |   |   |
             *      |   |   |   |   |   |
             *     [15][16][17][18][19][20]
             *          |   |   |   |
             *          |   |   |   |
             *         [21][22][23][24]
             *              |   |
             *              |   |
             *             [25][26]
             */

            var node0 = new TestNode(0);
            var node1 = new TestNode(1);
            var node2 = new TestNode(2);
            var node3 = new TestNode(3);
            var node4 = new TestNode(4);
            var node5 = new TestNode(5);
            var node6 = new TestNode(6);
            var node7 = new TestNode(7);
            var node8 = new TestNode(8);
            var node9 = new TestNode(9);
            var node10 = new TestNode(10);
            var node11 = new TestNode(11);
            var node12 = new TestNode(12);
            var node13 = new TestNode(13);
            var node14 = new TestNode(14);
            var node15 = new TestNode(15);
            var node16 = new TestNode(16);
            var node17 = new TestNode(17);
            var node18 = new TestNode(18);
            var node19 = new TestNode(19);
            var node20 = new TestNode(20);
            var node21 = new TestNode(21);
            var node22 = new TestNode(22);
            var node23 = new TestNode(23);
            var node24 = new TestNode(24);
            var node25 = new TestNode(25);
            var node26 = new TestNode(26);

            node0.AddChild(node1);
            node0.AddChild(node2);

            node1.AddChild(node3);
            node1.AddChild(node4);

            node2.AddChild(node5);
            node2.AddChild(node6);

            node3.AddChild(node7);
            node3.AddChild(node8);

            node4.AddChild(node9);
            node4.AddChild(node10);

            node5.AddChild(node11);
            node5.AddChild(node12);

            node6.AddChild(node13);
            node6.AddChild(node14);

            node8.AddChild(node15);

            node9.AddChild(node16);

            node10.AddChild(node17);

            node11.AddChild(node18);

            node12.AddChild(node19);

            node13.AddChild(node20);

            node16.AddChild(node21);

            node17.AddChild(node22);

            node18.AddChild(node23);

            node19.AddChild(node24);

            node22.AddChild(node25);

            node23.AddChild(node26);

            return node0;
        }

        public static TestNode CreateDAGWithSharedChild()
        {
            /*
             * [0]
             *  |____________________
             *  |                    |
             * [1]                  [2]
             *  |____________        |_______
             *  |            |       |       |
             * [3]          [4]     [5]     [6]
             *  |____        |___    |___    |_______
             *  |    |       |   |   |   |   |       |
             * [7]  [8]     [9] [10][11][12][13]    [14]
             *  |    |       |           |   |       |
             *  |    |       |           |   |       |
             * [15] [16]    [17]        [18][19]    [20]
             *  |__  |__[22] |           |   |__     |______
             *  |  | |       |           |   |  |    |      |
             * [21]|_|_______|_[23]      |  [24]|    |      |
             *                           |______|____|_[25][26]
             */

            var node0 = new TestNode(0);
            var node1 = new TestNode(1);
            var node2 = new TestNode(2);
            var node3 = new TestNode(3);
            var node4 = new TestNode(4);
            var node5 = new TestNode(5);
            var node6 = new TestNode(6);
            var node7 = new TestNode(7);
            var node8 = new TestNode(8);
            var node9 = new TestNode(9);
            var node10 = new TestNode(10);
            var node11 = new TestNode(11);
            var node12 = new TestNode(12);
            var node13 = new TestNode(13);
            var node14 = new TestNode(14);
            var node15 = new TestNode(15);
            var node16 = new TestNode(16);
            var node17 = new TestNode(17);
            var node18 = new TestNode(18);
            var node19 = new TestNode(19);
            var node20 = new TestNode(20);
            var node21 = new TestNode(21);
            var node22 = new TestNode(22);
            var node23 = new TestNode(23);
            var node24 = new TestNode(24);
            var node25 = new TestNode(25);
            var node26 = new TestNode(26);

            node0.AddChild(node1);
            node0.AddChild(node2);

            node1.AddChild(node3);
            node1.AddChild(node4);

            node2.AddChild(node5);
            node2.AddChild(node6);

            node3.AddChild(node7);
            node3.AddChild(node8);

            node4.AddChild(node9);
            node4.AddChild(node10);

            node5.AddChild(node11);
            node5.AddChild(node12);

            node6.AddChild(node13);
            node6.AddChild(node14);

            node7.AddChild(node15);

            node8.AddChild(node16);

            node9.AddChild(node17);

            node12.AddChild(node18);

            node13.AddChild(node19);

            node14.AddChild(node20);

            node15.AddChild(node21);
            node15.AddChild(node23);

            node16.AddChild(node23);
            node16.AddChild(node22);

            node17.AddChild(node23);

            node18.AddChild(node25);

            node19.AddChild(node24);
            node19.AddChild(node25);

            node20.AddChild(node25);
            node20.AddChild(node26);

            return node0;
        }

        public static TestNode CreateDAGWithManyParnetSharingChild()
        {
            /*
             * [0]
             *  |_______________________________
             *  |   |   |   |   |   |   |   |   |
             * [1] [2] [3] [4] [5] [6] [7] [8] [9]
             *  |___|___|___|___|___|___|___|___|_[10]
             */

            var node0 = new TestNode(0);
            var node1 = new TestNode(1);
            var node2 = new TestNode(2);
            var node3 = new TestNode(3);
            var node4 = new TestNode(4);
            var node5 = new TestNode(5);
            var node6 = new TestNode(6);
            var node7 = new TestNode(7);
            var node8 = new TestNode(8);
            var node9 = new TestNode(9);
            var node10 = new TestNode(10);

            node0.AddChild(node1);
            node0.AddChild(node2);
            node0.AddChild(node3);
            node0.AddChild(node4);
            node0.AddChild(node5);
            node0.AddChild(node6);
            node0.AddChild(node7);
            node0.AddChild(node8);
            node0.AddChild(node9);

            node1.AddChild(node10);

            node2.AddChild(node10);

            node3.AddChild(node10);

            node4.AddChild(node10);

            node5.AddChild(node10);

            node6.AddChild(node10);

            node7.AddChild(node10);

            node8.AddChild(node10);

            node9.AddChild(node10);

            return node0;
        }

        public static TestNode CreateDAGWithDuplicateSharingChildTwice()
        {
            /*
             * [0]
             *  |___
             *  |   |
             *  |___|_[1]
             *         |___
             *         |   |
             *         |___|_[2]
             */

            var node0 = new TestNode(0);
            var node1 = new TestNode(1);
            var node2 = new TestNode(2);

            node0.AddChild(node1);
            node0.AddChild(node1);
            node1.AddChild(node2);
            node1.AddChild(node2);

            return node0;
        }

        public static TestNode CreateGraphWithFarCycle()
        {
            /*
             *     [0]
             *      |____________________
             *      |                    |
             *     [1]                  [2]
             *      |____________        |_______
             *      |            |       |       |
             *     [3]          [4]     [5]     [6]
             *      |____        |___    |___    |_______
             *      |    |       |   |   |   |   |       |
             *  .->[7]  [8]     [9] [10][11][12][13]    [14]
             *  |   |    |       |           |   |       |
             *  |   |    |       |           |   |       |
             *  |  [15] [16]    [17]        [18][19]    [20]
             *  |   |__  |__[22] |           |   |__     |______
             *  |   |  | |       |           |   |  |    |      |
             *  |  [21]|_|_______|_[23]      |  [24]|    |      |
             *  |___________________|        |______|____|_[25][26]
             */

            var node0 = new TestNode(0);
            var node1 = new TestNode(1);
            var node2 = new TestNode(2);
            var node3 = new TestNode(3);
            var node4 = new TestNode(4);
            var node5 = new TestNode(5);
            var node6 = new TestNode(6);
            var node7 = new TestNode(7);
            var node8 = new TestNode(8);
            var node9 = new TestNode(9);
            var node10 = new TestNode(10);
            var node11 = new TestNode(11);
            var node12 = new TestNode(12);
            var node13 = new TestNode(13);
            var node14 = new TestNode(14);
            var node15 = new TestNode(15);
            var node16 = new TestNode(16);
            var node17 = new TestNode(17);
            var node18 = new TestNode(18);
            var node19 = new TestNode(19);
            var node20 = new TestNode(20);
            var node21 = new TestNode(21);
            var node22 = new TestNode(22);
            var node23 = new TestNode(23);
            var node24 = new TestNode(24);
            var node25 = new TestNode(25);
            var node26 = new TestNode(26);

            node0.AddChild(node1);
            node0.AddChild(node2);

            node1.AddChild(node3);
            node1.AddChild(node4);

            node2.AddChild(node5);
            node2.AddChild(node6);

            node3.AddChild(node7);
            node3.AddChild(node8);

            node4.AddChild(node9);
            node4.AddChild(node10);

            node5.AddChild(node11);
            node5.AddChild(node12);

            node6.AddChild(node13);
            node6.AddChild(node14);

            node7.AddChild(node15);

            node8.AddChild(node16);

            node9.AddChild(node17);

            node12.AddChild(node18);

            node13.AddChild(node19);

            node14.AddChild(node20);

            node15.AddChild(node21);
            node15.AddChild(node23);

            node16.AddChild(node23);
            node16.AddChild(node22);

            node17.AddChild(node23);

            node18.AddChild(node25);

            node19.AddChild(node24);
            node19.AddChild(node25);

            node20.AddChild(node25);
            node20.AddChild(node26);

            node23.AddChild(node7);

            return node0;
        }

        public static TestNode CreateGraphWithSelfCycle()
        {
            /*
             * [0]
             *  |____________________
             *  |                    |
             * [1]                  [2]
             *  |____________        |_______
             *  |            |       |       |
             * [3]          [4]     [5]     [6]
             *  |____        |___    |___    |_______
             *  |    |       |   |   |   |   |       |
             * [7]  [8]     [9] [10][11][12][13]    [14]
             *  |    |       |           |   |       |
             *  |    |       |  <-.      |   |       |
             * [15] [16]    [17]__|     [18][19]    [20]
             *  |__  |__[22] |           |   |__     |______
             *  |  | |       |           |   |  |    |      |
             * [21]|_|_______|_[23]      |  [24]|    |      |
             *                           |______|____|_[25][26]
             */

            var node0 = new TestNode(0);
            var node1 = new TestNode(1);
            var node2 = new TestNode(2);
            var node3 = new TestNode(3);
            var node4 = new TestNode(4);
            var node5 = new TestNode(5);
            var node6 = new TestNode(6);
            var node7 = new TestNode(7);
            var node8 = new TestNode(8);
            var node9 = new TestNode(9);
            var node10 = new TestNode(10);
            var node11 = new TestNode(11);
            var node12 = new TestNode(12);
            var node13 = new TestNode(13);
            var node14 = new TestNode(14);
            var node15 = new TestNode(15);
            var node16 = new TestNode(16);
            var node17 = new TestNode(17);
            var node18 = new TestNode(18);
            var node19 = new TestNode(19);
            var node20 = new TestNode(20);
            var node21 = new TestNode(21);
            var node22 = new TestNode(22);
            var node23 = new TestNode(23);
            var node24 = new TestNode(24);
            var node25 = new TestNode(25);
            var node26 = new TestNode(26);

            node0.AddChild(node1);
            node0.AddChild(node2);

            node1.AddChild(node3);
            node1.AddChild(node4);

            node2.AddChild(node5);
            node2.AddChild(node6);

            node3.AddChild(node7);
            node3.AddChild(node8);

            node4.AddChild(node9);
            node4.AddChild(node10);

            node5.AddChild(node11);
            node5.AddChild(node12);

            node6.AddChild(node13);
            node6.AddChild(node14);

            node7.AddChild(node15);

            node8.AddChild(node16);

            node9.AddChild(node17);

            node12.AddChild(node18);

            node13.AddChild(node19);

            node14.AddChild(node20);

            node15.AddChild(node21);
            node15.AddChild(node23);

            node16.AddChild(node23);
            node16.AddChild(node22);

            node17.AddChild(node23);

            node18.AddChild(node25);

            node19.AddChild(node24);
            node19.AddChild(node25);

            node20.AddChild(node25);
            node20.AddChild(node26);

            node17.AddChild(node17);

            return node0;
        }

        public static TestNode CreateGraphWithParentAndChildCycle()
        {
            /*
             * [0]
             *  |____________________
             *  |                    |
             * [1]                  [2]
             *  |____________        |_______
             *  |            |       |       |
             * [3]          [4]     [5]     [6]
             *  |____        |___    |___    |_______
             *  |    |       |   |   |   |   |       |
             * [7]  [8]     [9] [10][11][12][13]    [14]
             *  |    |       |           |   |       |
             *  |    |       |           |   |       |
             * [15] [16]    [17]     .->[18][19]    [20]
             *  |__  |__[22] |       |   |   |__     |______
             *  |  | |       |       |   |   |  |    |      |
             * [21]|_|_______|_[23]  |   |  [24]|    |      |
             *                       |   |______|____|_[25][26]
             *                       |__________________|
             */

            var node0 = new TestNode(0);
            var node1 = new TestNode(1);
            var node2 = new TestNode(2);
            var node3 = new TestNode(3);
            var node4 = new TestNode(4);
            var node5 = new TestNode(5);
            var node6 = new TestNode(6);
            var node7 = new TestNode(7);
            var node8 = new TestNode(8);
            var node9 = new TestNode(9);
            var node10 = new TestNode(10);
            var node11 = new TestNode(11);
            var node12 = new TestNode(12);
            var node13 = new TestNode(13);
            var node14 = new TestNode(14);
            var node15 = new TestNode(15);
            var node16 = new TestNode(16);
            var node17 = new TestNode(17);
            var node18 = new TestNode(18);
            var node19 = new TestNode(19);
            var node20 = new TestNode(20);
            var node21 = new TestNode(21);
            var node22 = new TestNode(22);
            var node23 = new TestNode(23);
            var node24 = new TestNode(24);
            var node25 = new TestNode(25);
            var node26 = new TestNode(26);

            node0.AddChild(node1);
            node0.AddChild(node2);

            node1.AddChild(node3);
            node1.AddChild(node4);

            node2.AddChild(node5);
            node2.AddChild(node6);

            node3.AddChild(node7);
            node3.AddChild(node8);

            node4.AddChild(node9);
            node4.AddChild(node10);

            node5.AddChild(node11);
            node5.AddChild(node12);

            node6.AddChild(node13);
            node6.AddChild(node14);

            node7.AddChild(node15);

            node8.AddChild(node16);

            node9.AddChild(node17);

            node12.AddChild(node18);

            node13.AddChild(node19);

            node14.AddChild(node20);

            node15.AddChild(node21);
            node15.AddChild(node23);

            node16.AddChild(node23);
            node16.AddChild(node22);

            node17.AddChild(node23);

            node18.AddChild(node25);

            node19.AddChild(node24);
            node19.AddChild(node25);

            node20.AddChild(node25);
            node20.AddChild(node26);

            node25.AddChild(node18);

            return node0;
        }
    }
}
