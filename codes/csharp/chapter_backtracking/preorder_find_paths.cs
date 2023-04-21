﻿/**
 * File: preorder_find_paths.cs
 * Created Time: 2023-04-17
 * Author: hpstory (hpstory1024@163.com)
 */

using hello_algo.include;
using NUnit.Framework;

namespace hello_algo.chapter_backtracking;

public class preorder_find_paths
{
    static List<TreeNode> path;
    static List<List<TreeNode>> res;

    /* 前序遍历 */
    static void preOrder(TreeNode root)
    {
        if (root == null)
        {
            return;
        }
        // 尝试
        path.Add(root);
        if (root.val == 7)
        {
            // 记录解
            res.Add(new List<TreeNode>(path));
        }
        preOrder(root.left);
        preOrder(root.right);
        // 回退
        path.RemoveAt(path.Count - 1);
    }

    [Test]
    public void Test()
    {
        TreeNode root = TreeNode.ListToTree(new List<int?> { 1, 7, 3, 4, 5, 6, 7 });
        Console.WriteLine("\n初始化二叉树");
        PrintUtil.PrintTree(root);

        // 前序遍历
        path = new List<TreeNode>();
        res = new List<List<TreeNode>>();
        preOrder(root);

        Console.WriteLine("\n输出所有根节点到节点 7 的路径");
        foreach (List<TreeNode> path in res)
        {
            PrintUtil.PrintList(path.Select(p => p.val).ToList());
        }
    }
}