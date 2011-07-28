﻿using NSubstitute;
using NUnit.Framework;
using Neo4jClient.Gremlin;

namespace Neo4jClient.Test
{
    [TestFixture]
    public class NodeTests
    {
        [Test]
        public void ClientShouldReturnClientFromReference()
        {
            var client = Substitute.For<IGraphClient>();
            var reference = new NodeReference<object>(123, client);
            var node = new Node<object>(new object(), reference);
            Assert.AreEqual(client, ((IGremlinQuery)node).Client);
        }

        [Test]
        public void QueryTextShouldReturnSimpleVectorStep()
        {
            var client = Substitute.For<IGraphClient>();
            var reference = new NodeReference<object>(123, client);
            var node = new Node<object>(new object(), reference);
            Assert.AreEqual("g.v(123)", ((IGremlinQuery)node).QueryText);
        }

        [Test]
        public void EqualityOperatorShouldReturnTrueForEquivalentReferences()
        {
            var node1 = new Node<object>(new object(), new NodeReference<object>(123));
            var node2 = new Node<object>(new object(), new NodeReference<object>(123));
            Assert.IsTrue(node1 == node2);
        }

        [Test]
        public void EqualityOperatorShouldReturnFalseForDifferentReferences()
        {
            var node1 = new Node<object>(new object(), new NodeReference<object>(123));
            var node2 = new Node<object>(new object(), new NodeReference<object>(456));
            Assert.IsFalse(node1 == node2);
        }

        [Test]
        public void GetHashCodeShouldReturnNodeId()
        {
            var node = new Node<object>(new object(), new NodeReference<object>(123));
            Assert.AreEqual(123, node.Reference.Id);
        }
    }
}